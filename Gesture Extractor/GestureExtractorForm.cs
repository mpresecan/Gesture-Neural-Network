using Gesture_Extractor.NeuroComputing;
using Gesture_Extractor.Utilities_;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gesture_Extractor
{
    public partial class GestureExtractorForm : Form
    {
        bool startTrain = false;
        bool startTest = false;
        int xTest = 0;
        int yTest = 0;
        int xTrain = 0;
        int yTrain = 0;
        Graphics gpTrain;
        Graphics gpTest;
        Gesture TrackerListTrain;
        Gesture TrackerListTest;
        Stack<string> historyClassSaved;
        ObservableDictionary<string, Stack<Gesture>> trainingSet;
        bool mouseMoved = false;
        NeuralNetwork NN;
        public int M { get; private set; }
        List<int> topology;
        private int timeSec;
        private int i = 0;

        public int TimeSec {
            get {
                return timeSec;
            }
            set {
                timeSec = value;
                labelTime.Text = "Time: " + TimeSpan.FromMilliseconds(TimeSec * timerTraining.Interval).ToString();
            } }

        public GestureExtractorForm()
        {
            InitializeComponent();
            trainingSet = new ObservableDictionary<string, Stack<Gesture>>();
            historyClassSaved = new Stack<string>();
            gpTrain = panelDraw.CreateGraphics();
            gpTest = panelTest.CreateGraphics();

            listBoxTrainData.Items.Add("CLASS\tNo.Classes");
            textBoxClassValue.Text = "alpha"; // TODO: remove later
            M = int.Parse(textBoxSampleRate.Text);
            labelEtha.Text = "";

            trainingSet.CollectionChanged += OnTrainingSetChanged;
            richTextBoxInfo.Text = Properties.Resources.InfoText;
        }

        void OnTrainingSetChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Reset)
            {
                if (trainingSet.Count < 2)
                    buttonTrain.Enabled = false;
                else
                {
                    topology = createNetworkTopology(trainingSet, textBoxTopology.Text);
                    NN = new NeuralNetwork(topology, checkBoxParallel.Checked);
                    buttonTrain.Enabled = true;
                }
            }
            textBoxSampleRate.Enabled = trainingSet.Count == 0 ? true : false;
        }

        private List<int> createNetworkTopology(ObservableDictionary<string, Stack<Gesture>> trainingSet, string hiddenTopology)
        {
            List<int> topology = new List<int>();
            int mX2 = trainingSet[trainingSet.Keys.First()].First().Count * 2;
            topology.Add(mX2);
            string[] hiddenLayersStrings = hiddenTopology.Split(',');
            foreach (string hiddenLayerString in hiddenLayersStrings)
                topology.Add(int.Parse(hiddenLayerString.Trim()));
            topology.Add(trainingSet.Count);
            return topology;
        }

        private List<int> createNetworkTopology(int M, string hiddenTopology, int noClasses)
        {
            List<int> topology = new List<int>();
            topology.Add(M * 2);
            string[] hiddenLayersStrings = hiddenTopology.Split(',');
            foreach (string hiddenLayerString in hiddenLayersStrings)
                topology.Add(int.Parse(hiddenLayerString.Trim()));
            topology.Add(noClasses);
            return topology;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mouseMoved)
            {
                startTrain = false;
                // paint interpolated points
                Gesture interpolated = Gesture.Interpolate(TrackerListTrain, M);
                Pen pen = new Pen(Brushes.Red, 6);
                foreach (Point p in interpolated)
                {
                    gpTrain.DrawLine(pen, new PointF(p.X, p.Y), new PointF(p.X + 1, p.Y + 1));
                }

                saveGesture(TrackerListTrain, textBoxClassValue.Text);
                mouseMoved = false;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startTrain && e.Button == MouseButtons.Left)
            {
                if (xTrain > 0 && yTrain > 0)
                {
                    Pen p = new Pen(Brushes.Yellow, 3);
                    gpTrain.DrawLine(p, xTrain, yTrain, e.X, e.Y);
                }

                xTrain = e.X;
                yTrain = e.Y;

                TrackerListTrain.Add(new Point(e.X, e.Y));
                mouseMoved = true;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (textBoxClassValue.Text == "")
                {
                    MessageBox.Show("Please enter the class name");
                    return;
                }

                if (xTrain != 0 || yTrain != 0)
                {
                    // clear the panel
                    clearTrainPanel();
                }

                startTrain = true;
                TrackerListTrain = new Gesture(textBoxClassValue.Text); 
            }
            else
            {
                buttonUndo.PerformClick();
            }
        }

        private void panelTrain_Resize(object sender, EventArgs e)
        {
            gpTrain = panelDraw.CreateGraphics();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            clearTrainPanel();
            if (trainingSet.Count == 0) return;
            trainingSet[historyClassSaved.Peek()].Pop();
            // was this the last gesture in this class?
            if (trainingSet[historyClassSaved.Peek()].Count == 0)
            {
                //if so remove it from the training set
                trainingSet.Remove(historyClassSaved.Peek());
            }
            historyClassSaved.Pop();
            textBoxClassValue.Text = historyClassSaved.Count > 0 ? historyClassSaved.Peek() : "";
            listTrainingData();
        }

        private void saveGesture(Gesture trackerList, string className)
        {
            Gesture transformed = Gesture.Transform(trackerList, M);
            historyClassSaved.Push(className);

            // if it doesnt have this class in traning set, create one
            if (!trainingSet.ContainsKey(className))
                trainingSet.Add(className, new Stack<Gesture>());

            trainingSet[className].Push(transformed);

            // list new training data
            listTrainingData();
            topologyShow();
        }

        private void listTrainingData()
        {
            listBoxTrainData.Items.Clear();

            listBoxTrainData.Items.Add("CLASS\tNo.Classes");
            foreach (var trainClass in trainingSet)
            {
                listBoxTrainData.Items.Add(trainClass.Key + "\t" + trainClass.Value.Count());
            }
        }

        private void clearTrainPanel()
        {
            panelDraw.Invalidate();
            xTrain = 0;
            yTrain = 0;
        }

        private void buttonSaveTrainingSet_Click(object sender, EventArgs e)
        {
            if (saveTrainingDataDialog.ShowDialog() == DialogResult.OK && saveTrainingDataDialog.CheckPathExists)
            {
                using (StreamWriter sw = new StreamWriter(saveTrainingDataDialog.FileName))
                {
                    foreach (var trainClass in trainingSet)
                    {
                        foreach (Gesture g in trainClass.Value)
                        {
                            writeGesture2File(trainClass.Key, g, sw);
                        }
                    }
                }
            }
        }

        private void writeGesture2File(string className, Gesture g, StreamWriter sw)
        {
            sw.Write(className + " ");
            foreach (Point p in g)
            {
                sw.Write(p + " ");
            }
            sw.WriteLine();
        }

        private void buttonLoadTrainingSet_Click(object sender, EventArgs e)
        {
            if (openFileDialogTrainingSet.ShowDialog() == DialogResult.OK && openFileDialogTrainingSet.CheckPathExists)
            {
                using (StreamReader sr = new StreamReader(openFileDialogTrainingSet.FileName))
                {
                    trainingSet = new ObservableDictionary<string, Stack<Gesture>>();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.TrimEnd();
                        string[] tokens = line.Split(' ');
                        string className = tokens[0];
                        Gesture g = new Gesture(className);
                        textBoxSampleRate.Text = (tokens.Length -1).ToString();
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            string pointString = tokens[i];
                            string[] pointsStr = pointString.Split(':');
                            float x = float.Parse(pointsStr[0].Substring(1).Trim());
                            float y = float.Parse(pointsStr[1].Substring(0, pointsStr[1].Length - 1));
                            Point p = new Point(x, y);
                            g.Add(p);
                        }
                        saveGesture(g, className); 
                    }
                    listTrainingData();
                    topology = createNetworkTopology(trainingSet, textBoxTopology.Text);
                    NN = new NeuralNetwork(topology, checkBoxParallel.Checked);
                    textBoxSampleRate.Enabled = trainingSet.Count == 0 ? true : false;
                    buttonTrain.Enabled = trainingSet.Count > 1 ? true : false;
                    buttonStopTrain.Enabled = false;
                    resetChart(chartError, "Error");
                    i = 0;
                }
            }
        }

        private void panelTest_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mouseMoved)
            {
                startTest = false;
                // paint interpolated points
                Gesture interpolated = Gesture.Interpolate(TrackerListTest, M);
                Pen pen = new Pen(Brushes.Red, 6);
                foreach (Point p in interpolated)
                {
                    gpTest.DrawLine(pen, new PointF(p.X, p.Y), new PointF(p.X + 1, p.Y + 1));
                }

                // TrackerListTest is the result -> send to forward pass
                List<double> inputs = Utilities.Gesture2Inputs(Gesture.Transform(TrackerListTest, M));
                List<double> nnOuput = NN.ForwardPass(inputs, checkBoxParallel.Checked);

                mouseMoved = false;


                plotResults(nnOuput);
            }
        }

        private void panelTest_MouseMove(object sender, MouseEventArgs e)
        {
            if (startTest && e.Button == MouseButtons.Left)
            {
                if (xTest > 0 && yTest > 0)
                {
                    Pen p = new Pen(Brushes.Yellow, 3);
                    gpTest.DrawLine(p, xTest, yTest, e.X, e.Y);
                }

                xTest = e.X;
                yTest = e.Y;

                TrackerListTest.Add(new Point(e.X, e.Y));
                mouseMoved = true;
            }
        }

        private void panelTest_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (xTest != 0 || yTest != 0)
                {
                    // clear the panel
                    clearTrainPanel();
                    clearTestPanel();
                }

                startTest = true;
                TrackerListTest = new Gesture();
            }
            else
            {
                clearTestPanel();
            }
            resetChart(chartResults, "Probability");
        }

        private void clearTestPanel()
        {
            panelTest.Invalidate();
            xTest = 0;
            yTest = 0;
        }

        private void plotResults(List<double> y)
        {
            for (int i = 0; i < y.Count; i++)
            {
                string className = new List<string>(trainingSet.Keys).ElementAt(i);
                chartResults.Series["Probability"].Points.AddXY(className, y[i]);
            }
        }

        private void resetChart(Chart chart, string series)
        {
            chart.Series[series].Points.Clear();
        }

        private void train(int i)
        {
            List<Tuple<List<double>, List<double>>> trainigSetReady = prepareDataForTraining(trainingSet);

            if (radioButtonStohastic.Checked)
            {
                if (checkBoxEthaLinear.Checked)
                    NN.TrainStohastic(trainigSetReady, i, iter: int.Parse(textBoxIter.Text), minEtha: double.Parse(textBoxEthaTo.Text), maxEtha: double.Parse(textBoxEthaFrom.Text), parallel: checkBoxParallel.Checked, bw: backgroundWorkerTrainer);
                else NN.TrainStohastic(trainigSetReady, i, fixedEtha: double.Parse(textBoxFixedEtha.Text), parallel: checkBoxParallel.Checked, bw: backgroundWorkerTrainer);
            }
            else if (radioButtonMiniBatch.Checked)
            {
                if (checkBoxEthaLinear.Checked)
                    NN.TrainMiniBatch(trainigSetReady, i, int.Parse(textBoxMiniBatchSize.Text), iter: int.Parse(textBoxIter.Text), minEtha: double.Parse(textBoxEthaTo.Text), maxEtha: double.Parse(textBoxEthaFrom.Text), parallel: checkBoxParallel.Checked, bw: backgroundWorkerTrainer);
                else NN.TrainMiniBatch(trainigSetReady, i, int.Parse(textBoxMiniBatchSize.Text), fixedEtha: double.Parse(textBoxFixedEtha.Text), parallel: checkBoxParallel.Checked, bw: backgroundWorkerTrainer);
            }
            else
            {
                if (checkBoxEthaLinear.Checked)
                    NN.TrainBatch(trainigSetReady, i, iter: int.Parse(textBoxIter.Text), minEtha: double.Parse(textBoxEthaTo.Text), maxEtha: double.Parse(textBoxEthaFrom.Text), parallel: checkBoxParallel.Checked, bw: backgroundWorkerTrainer);
                else
                    NN.TrainBatch(trainigSetReady, i, fixedEtha: double.Parse(textBoxFixedEtha.Text), parallel: checkBoxParallel.Checked, bw: backgroundWorkerTrainer);
            }
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerTrainer.IsBusy)
            {
                if (i == 0) NN = new NeuralNetwork(topology, checkBoxParallel.Checked);
                backgroundWorkerTrainer.RunWorkerAsync();
                buttonTrain.Text = "PAUSE";
                buttonStopTrain.Enabled = true;
                if (i == 0) timeSec = 0;
                timerTraining.Start();
            }
            else
            {
                backgroundWorkerTrainer.CancelAsync();
                buttonTrain.Text = "TRAIN";
                timerTraining.Stop();
            } 
        }

        private List<Tuple<List<double>, List<double>>> prepareDataForTraining(ObservableDictionary<string, Stack<Gesture>> trainingSet)
        {
            Random rnd = new Random();
            Dictionary<string, Stack<Gesture>> trainingSetCopy = copyTrainingSet(trainingSet);
            List<Tuple<List<double>, List<double>>> trainingSetReady = new List<Tuple<List<double>, List<double>>>();
            List<string> trainingClasses = new List<string>(trainingSet.Keys);
            while (trainingSetCopy.Keys.Count > 0)
            {
                int i = rnd.Next(trainingSetCopy.Keys.Count);
                string className = trainingSetCopy.Keys.ElementAt(i);
                Gesture g = trainingSetCopy[className].Pop();
                Tuple<List<double>, List<double>> trainExample = new Tuple<List<double>, List<double>>(oneHotCoding(g, trainingClasses).ToList(), gesture2NNType(g));
                trainingSetReady.Add(trainExample);

                if (trainingSetCopy[className].Count == 0)
                {
                    trainingSetCopy.Remove(className); // if all gestures from this class are out, take that class out from dictionary
                }
            }
            return trainingSetReady;
        }

        private Dictionary<string, Stack<Gesture>> copyTrainingSet(ObservableDictionary<string, Stack<Gesture>> trainingSet)
        {
            Dictionary<string, Stack<Gesture>> trainingSetCopy = new Dictionary<string, Stack<Gesture>>();
            foreach (string className in trainingSet.Keys)
            {
                Stack<Gesture> classStack = new Stack<Gesture>();
                foreach (Gesture g in trainingSet[className])
                {
                    classStack.Push(g.Copy());
                }
                trainingSetCopy[className] = classStack;
            }
            return trainingSetCopy;
        }

        private List<double> gesture2NNType(Gesture g)
        {
            List<double> list = new List<double>();
            foreach (Point p in g)
            {
                list.Add(p.X);
                list.Add(p.Y);
            }
            return list;
        }

        private double[] oneHotCoding(Gesture g, List<string> trainingClasses)
        {
            double[] oneHotCodedGesture = new double[trainingClasses.Count];
            int index = trainingClasses.IndexOf(g.ClassName);
            oneHotCodedGesture[index] = 1.0f;
            return oneHotCodedGesture;
        }

        private void topologyShow()
        {
            labelTopology.Text = "Topology: " + (M * 2).ToString() + ", " + textBoxTopology.Text + ", " + trainingSet.Count.ToString();
        }

        private void radioButtonMiniBatch_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMiniBatchSize.Enabled = radioButtonMiniBatch.Checked;
        }

        private void checkBoxEthaLinear_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFixedEtha.Enabled = !checkBoxEthaLinear.Checked;
            textBoxIter.Enabled = checkBoxEthaLinear.Checked;
            textBoxEthaFrom.Enabled = checkBoxEthaLinear.Checked;
            textBoxEthaTo.Enabled = checkBoxEthaLinear.Checked;
            if (!checkBoxEthaLinear.Checked) labelEtha.Text = "";
            else labelEtha.Text = "Etha: 1.0";
            
        }

        private void backgroundWorkerTrain_DoWork(object sender, DoWorkEventArgs e)
        {
            train(i);
        }

        private void backgroundWorkerTrain_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Report r = (Report)e.UserState;
            chartError.Series["Error"].Points.AddXY(r.i, r.E);
            chartError.Update();

            labelError.Text = "Error: " + r.E.ToString();
            //labelEtha.Text = "Etha: " + r.etha.ToString();
            labelEtha.Text = "Etha: " + String.Format("{0:0.00000}", r.etha);

            i = r.i;
        }

        private void backgroundWorkerTrain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        private void buttonStopTrain_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerTrainer.IsBusy)
            {
                backgroundWorkerTrainer.CancelAsync();
                buttonTrain.Text = "TRAIN";
                timerTraining.Stop();
            }
            i = 0;
            resetChart(chartError, "Error");
            NN = new NeuralNetwork(topology, checkBoxParallel.Checked);
            buttonStopTrain.Enabled = false;
            TimeSec = 0;
        }

        private void textBoxEthaFrom_Leave(object sender, EventArgs e)
        {
            if (!textBoxEthaFrom.Text.IsNumber())
                textBoxEthaFrom.Text = "1";
            else
            {
                if (double.Parse(textBoxEthaFrom.Text) >= 1)
                    textBoxEthaFrom.Text = "1";
                if (double.Parse(textBoxEthaFrom.Text) < double.Parse(textBoxEthaTo.Text))
                    textBoxEthaFrom.Text = "1";
            }
        }

        private void textBoxEthaTo_Leave(object sender, EventArgs e)
        {
            if (!textBoxEthaTo.Text.IsNumber())
                textBoxEthaTo.Text = Utilities.SmallEtha.ToString();
            else
            {
                if (double.Parse(textBoxEthaTo.Text) <= 0)
                    textBoxEthaTo.Text = Utilities.SmallEtha.ToString();
                if (double.Parse(textBoxEthaFrom.Text) < double.Parse(textBoxEthaTo.Text))
                    textBoxEthaTo.Text = Utilities.SmallEtha.ToString();
            }
        }

        private void textBoxTopology_Leave(object sender, EventArgs e)
        {
            string[] layersStrings = textBoxTopology.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string layer in layersStrings)
            {
                if (!layer.IsNumber())
                {
                    textBoxTopology.Text = "100";
                    return;
                }
            }
            if (trainingSet.Count > 1)
            {
                topology = createNetworkTopology(trainingSet, textBoxTopology.Text);
                NN = new NeuralNetwork(topology, checkBoxParallel.Checked);
            }
            topologyShow();
        }

        private void textBoxFixedEtha_Leave(object sender, EventArgs e)
        {
            if (!textBoxFixedEtha.Text.IsNumber())
            {
                textBoxFixedEtha.Text = Utilities.DefaultEtha.ToString();
            }
        }

        private void textBoxMiniBatchSize_Leave(object sender, EventArgs e)
        {
            if (!textBoxMiniBatchSize.Text.IsNumber())
            {
                textBoxMiniBatchSize.Text = Utilities.DefaultMiniBatchSize.ToString();
            }
        }

        private void textBoxSampleRate_Leave(object sender, EventArgs e)
        {
            if (!textBoxSampleRate.Text.IsNumber())
            {
                textBoxSampleRate.Text = Utilities.DefaultSampleRate.ToString();
            }
            else M = int.Parse(textBoxSampleRate.Text);
        }

        private void panelTest_Resize(object sender, EventArgs e)
        {
            gpTest = panelTest.CreateGraphics();
        }

        private void buttonClearTrainingSet_Click(object sender, EventArgs e)
        {
            clearTrainPanel();
            trainingSet = new ObservableDictionary<string, Stack<Gesture>>();
            trainingSet.CollectionChanged += OnTrainingSetChanged;
            listTrainingData();
            textBoxSampleRate.Enabled = true;
            buttonTrain.Enabled = false;
        }

        private void timerTraining_Tick(object sender, EventArgs e)
        {
            TimeSec++;
        }
    }
}
