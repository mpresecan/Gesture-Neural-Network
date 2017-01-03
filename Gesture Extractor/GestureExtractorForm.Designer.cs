namespace Gesture_Extractor
{
    partial class GestureExtractorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestureExtractorForm));
            this.panelDraw = new System.Windows.Forms.Panel();
            this.tabControlTrain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelError = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelEtha = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTrainResults = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStopTrain = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxEthaLinear = new System.Windows.Forms.CheckBox();
            this.checkBoxParallel = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFixedEtha = new System.Windows.Forms.TextBox();
            this.textBoxEthaTo = new System.Windows.Forms.TextBox();
            this.textBoxEthaFrom = new System.Windows.Forms.TextBox();
            this.textBoxIter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTopology = new System.Windows.Forms.TextBox();
            this.labelTopology = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxMiniBatchSize = new System.Windows.Forms.TextBox();
            this.radioButtonStohastic = new System.Windows.Forms.RadioButton();
            this.radioButtonMiniBatch = new System.Windows.Forms.RadioButton();
            this.radioButtonBatch = new System.Windows.Forms.RadioButton();
            this.buttonLoadTrainingSet = new System.Windows.Forms.Button();
            this.buttonSaveTrainingSet = new System.Windows.Forms.Button();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panelTrainControl = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClearTrainingSet = new System.Windows.Forms.Button();
            this.labelSampleRate = new System.Windows.Forms.Label();
            this.textBoxSampleRate = new System.Windows.Forms.TextBox();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.listBoxTrainData = new System.Windows.Forms.ListBox();
            this.textBoxClassValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chartError = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelTest = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.saveTrainingDataDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogTrainingSet = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorkerTrainer = new System.ComponentModel.BackgroundWorker();
            this.timerTraining = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlTrain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelTrainResults.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panelTrainControl.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDraw
            // 
            this.panelDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDraw.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelDraw.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelDraw.Location = new System.Drawing.Point(139, 4);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(419, 340);
            this.panelDraw.TabIndex = 0;
            this.panelDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panelDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panelDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panelDraw.Resize += new System.EventHandler(this.panelTrain_Resize);
            // 
            // tabControlTrain
            // 
            this.tabControlTrain.Controls.Add(this.tabPage1);
            this.tabControlTrain.Controls.Add(this.tabPage2);
            this.tabControlTrain.Controls.Add(this.tabPage3);
            this.tabControlTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTrain.Location = new System.Drawing.Point(0, 0);
            this.tabControlTrain.Name = "tabControlTrain";
            this.tabControlTrain.SelectedIndex = 0;
            this.tabControlTrain.Size = new System.Drawing.Size(737, 541);
            this.tabControlTrain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.panelTrainResults);
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(729, 515);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Train";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelTime,
            this.labelEtha,
            this.labelError});
            this.statusStrip1.Location = new System.Drawing.Point(3, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(723, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelTime
            // 
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(85, 17);
            this.labelTime.Text = "Time:  00:00:00";
            // 
            // labelError
            // 
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(35, 17);
            this.labelError.Text = "Error:";
            // 
            // labelEtha
            // 
            this.labelEtha.Name = "labelEtha";
            this.labelEtha.Size = new System.Drawing.Size(36, 17);
            this.labelEtha.Text = "Etha: ";
            // 
            // panelTrainResults
            // 
            this.panelTrainResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTrainResults.Controls.Add(this.groupBox1);
            this.panelTrainResults.Location = new System.Drawing.Point(573, 3);
            this.panelTrainResults.Name = "panelTrainResults";
            this.panelTrainResults.Size = new System.Drawing.Size(153, 484);
            this.panelTrainResults.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStopTrain);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.buttonLoadTrainingSet);
            this.groupBox1.Controls.Add(this.buttonSaveTrainingSet);
            this.groupBox1.Controls.Add(this.buttonTrain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 484);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Training Control";
            // 
            // buttonStopTrain
            // 
            this.buttonStopTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopTrain.Enabled = false;
            this.buttonStopTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStopTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStopTrain.Location = new System.Drawing.Point(89, 436);
            this.buttonStopTrain.Name = "buttonStopTrain";
            this.buttonStopTrain.Size = new System.Drawing.Size(59, 36);
            this.buttonStopTrain.TabIndex = 18;
            this.buttonStopTrain.Text = "STOP";
            this.buttonStopTrain.UseVisualStyleBackColor = true;
            this.buttonStopTrain.Click += new System.EventHandler(this.buttonStopTrain_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.checkBoxEthaLinear);
            this.groupBox5.Controls.Add(this.checkBoxParallel);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.textBoxFixedEtha);
            this.groupBox5.Controls.Add(this.textBoxEthaTo);
            this.groupBox5.Controls.Add(this.textBoxEthaFrom);
            this.groupBox5.Controls.Add(this.textBoxIter);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(7, 224);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(141, 148);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Learning Parameters";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "to";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "from";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "In:";
            // 
            // checkBoxEthaLinear
            // 
            this.checkBoxEthaLinear.AutoSize = true;
            this.checkBoxEthaLinear.Location = new System.Drawing.Point(6, 45);
            this.checkBoxEthaLinear.Name = "checkBoxEthaLinear";
            this.checkBoxEthaLinear.Size = new System.Drawing.Size(127, 17);
            this.checkBoxEthaLinear.TabIndex = 11;
            this.checkBoxEthaLinear.Text = "Change Etha Linearly";
            this.checkBoxEthaLinear.UseVisualStyleBackColor = true;
            this.checkBoxEthaLinear.CheckedChanged += new System.EventHandler(this.checkBoxEthaLinear_CheckedChanged);
            // 
            // checkBoxParallel
            // 
            this.checkBoxParallel.AutoSize = true;
            this.checkBoxParallel.Location = new System.Drawing.Point(6, 125);
            this.checkBoxParallel.Name = "checkBoxParallel";
            this.checkBoxParallel.Size = new System.Drawing.Size(112, 17);
            this.checkBoxParallel.TabIndex = 0;
            this.checkBoxParallel.Text = "Parllel / Multi-Core";
            this.checkBoxParallel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fixed Etha:";
            // 
            // textBoxFixedEtha
            // 
            this.textBoxFixedEtha.Location = new System.Drawing.Point(69, 18);
            this.textBoxFixedEtha.Name = "textBoxFixedEtha";
            this.textBoxFixedEtha.Size = new System.Drawing.Size(64, 20);
            this.textBoxFixedEtha.TabIndex = 7;
            this.textBoxFixedEtha.Text = "0.01";
            this.textBoxFixedEtha.Leave += new System.EventHandler(this.textBoxFixedEtha_Leave);
            // 
            // textBoxEthaTo
            // 
            this.textBoxEthaTo.Enabled = false;
            this.textBoxEthaTo.Location = new System.Drawing.Point(82, 86);
            this.textBoxEthaTo.Name = "textBoxEthaTo";
            this.textBoxEthaTo.Size = new System.Drawing.Size(51, 20);
            this.textBoxEthaTo.TabIndex = 10;
            this.textBoxEthaTo.Text = "0.0001";
            this.textBoxEthaTo.Leave += new System.EventHandler(this.textBoxEthaTo_Leave);
            // 
            // textBoxEthaFrom
            // 
            this.textBoxEthaFrom.Enabled = false;
            this.textBoxEthaFrom.Location = new System.Drawing.Point(33, 86);
            this.textBoxEthaFrom.Name = "textBoxEthaFrom";
            this.textBoxEthaFrom.Size = new System.Drawing.Size(32, 20);
            this.textBoxEthaFrom.TabIndex = 10;
            this.textBoxEthaFrom.Text = "1";
            this.textBoxEthaFrom.Leave += new System.EventHandler(this.textBoxEthaFrom_Leave);
            // 
            // textBoxIter
            // 
            this.textBoxIter.Enabled = false;
            this.textBoxIter.Location = new System.Drawing.Point(25, 64);
            this.textBoxIter.Name = "textBoxIter";
            this.textBoxIter.Size = new System.Drawing.Size(50, 20);
            this.textBoxIter.TabIndex = 10;
            this.textBoxIter.Text = "200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "iterations";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBoxTopology);
            this.groupBox4.Controls.Add(this.labelTopology);
            this.groupBox4.Location = new System.Drawing.Point(7, 141);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(141, 74);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Network Topology";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hiden Layer Topology";
            // 
            // textBoxTopology
            // 
            this.textBoxTopology.Location = new System.Drawing.Point(6, 32);
            this.textBoxTopology.Name = "textBoxTopology";
            this.textBoxTopology.Size = new System.Drawing.Size(129, 20);
            this.textBoxTopology.TabIndex = 11;
            this.textBoxTopology.Text = "100";
            this.textBoxTopology.Leave += new System.EventHandler(this.textBoxTopology_Leave);
            // 
            // labelTopology
            // 
            this.labelTopology.AutoSize = true;
            this.labelTopology.Location = new System.Drawing.Point(2, 55);
            this.labelTopology.Name = "labelTopology";
            this.labelTopology.Size = new System.Drawing.Size(54, 13);
            this.labelTopology.TabIndex = 13;
            this.labelTopology.Text = "Topology:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxMiniBatchSize);
            this.groupBox3.Controls.Add(this.radioButtonStohastic);
            this.groupBox3.Controls.Add(this.radioButtonMiniBatch);
            this.groupBox3.Controls.Add(this.radioButtonBatch);
            this.groupBox3.Location = new System.Drawing.Point(7, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 118);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Back Propagation";
            // 
            // textBoxMiniBatchSize
            // 
            this.textBoxMiniBatchSize.Location = new System.Drawing.Point(5, 88);
            this.textBoxMiniBatchSize.Name = "textBoxMiniBatchSize";
            this.textBoxMiniBatchSize.Size = new System.Drawing.Size(128, 20);
            this.textBoxMiniBatchSize.TabIndex = 3;
            this.textBoxMiniBatchSize.Text = "10";
            this.textBoxMiniBatchSize.Leave += new System.EventHandler(this.textBoxMiniBatchSize_Leave);
            // 
            // radioButtonStohastic
            // 
            this.radioButtonStohastic.AutoSize = true;
            this.radioButtonStohastic.Location = new System.Drawing.Point(6, 42);
            this.radioButtonStohastic.Name = "radioButtonStohastic";
            this.radioButtonStohastic.Size = new System.Drawing.Size(69, 17);
            this.radioButtonStohastic.TabIndex = 2;
            this.radioButtonStohastic.Text = "Stohastic";
            this.radioButtonStohastic.UseVisualStyleBackColor = true;
            // 
            // radioButtonMiniBatch
            // 
            this.radioButtonMiniBatch.AutoSize = true;
            this.radioButtonMiniBatch.Checked = true;
            this.radioButtonMiniBatch.Location = new System.Drawing.Point(6, 65);
            this.radioButtonMiniBatch.Name = "radioButtonMiniBatch";
            this.radioButtonMiniBatch.Size = new System.Drawing.Size(75, 17);
            this.radioButtonMiniBatch.TabIndex = 1;
            this.radioButtonMiniBatch.TabStop = true;
            this.radioButtonMiniBatch.Text = "Mini-Batch";
            this.radioButtonMiniBatch.UseVisualStyleBackColor = true;
            this.radioButtonMiniBatch.CheckedChanged += new System.EventHandler(this.radioButtonMiniBatch_CheckedChanged);
            // 
            // radioButtonBatch
            // 
            this.radioButtonBatch.AutoSize = true;
            this.radioButtonBatch.Location = new System.Drawing.Point(6, 19);
            this.radioButtonBatch.Name = "radioButtonBatch";
            this.radioButtonBatch.Size = new System.Drawing.Size(53, 17);
            this.radioButtonBatch.TabIndex = 0;
            this.radioButtonBatch.Text = "Batch";
            this.radioButtonBatch.UseVisualStyleBackColor = true;
            // 
            // buttonLoadTrainingSet
            // 
            this.buttonLoadTrainingSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadTrainingSet.FlatAppearance.BorderSize = 0;
            this.buttonLoadTrainingSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadTrainingSet.Location = new System.Drawing.Point(7, 407);
            this.buttonLoadTrainingSet.Name = "buttonLoadTrainingSet";
            this.buttonLoadTrainingSet.Size = new System.Drawing.Size(140, 23);
            this.buttonLoadTrainingSet.TabIndex = 3;
            this.buttonLoadTrainingSet.Text = "Load Training Set";
            this.buttonLoadTrainingSet.UseVisualStyleBackColor = true;
            this.buttonLoadTrainingSet.Click += new System.EventHandler(this.buttonLoadTrainingSet_Click);
            // 
            // buttonSaveTrainingSet
            // 
            this.buttonSaveTrainingSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveTrainingSet.FlatAppearance.BorderSize = 0;
            this.buttonSaveTrainingSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveTrainingSet.Location = new System.Drawing.Point(7, 378);
            this.buttonSaveTrainingSet.Name = "buttonSaveTrainingSet";
            this.buttonSaveTrainingSet.Size = new System.Drawing.Size(140, 23);
            this.buttonSaveTrainingSet.TabIndex = 2;
            this.buttonSaveTrainingSet.Text = "Save Training Set";
            this.buttonSaveTrainingSet.UseVisualStyleBackColor = true;
            this.buttonSaveTrainingSet.Click += new System.EventHandler(this.buttonSaveTrainingSet_Click);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTrain.Enabled = false;
            this.buttonTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTrain.Location = new System.Drawing.Point(7, 436);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(75, 36);
            this.buttonTrain.TabIndex = 1;
            this.buttonTrain.Text = "TRAIN";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(6, 6);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panelTrainControl);
            this.splitContainer2.Panel1.Controls.Add(this.panelDraw);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chartError);
            this.splitContainer2.Size = new System.Drawing.Size(561, 481);
            this.splitContainer2.SplitterDistance = 347;
            this.splitContainer2.TabIndex = 6;
            // 
            // panelTrainControl
            // 
            this.panelTrainControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTrainControl.Controls.Add(this.groupBox2);
            this.panelTrainControl.Location = new System.Drawing.Point(3, 4);
            this.panelTrainControl.Name = "panelTrainControl";
            this.panelTrainControl.Size = new System.Drawing.Size(130, 340);
            this.panelTrainControl.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonClearTrainingSet);
            this.groupBox2.Controls.Add(this.labelSampleRate);
            this.groupBox2.Controls.Add(this.textBoxSampleRate);
            this.groupBox2.Controls.Add(this.buttonUndo);
            this.groupBox2.Controls.Add(this.listBoxTrainData);
            this.groupBox2.Controls.Add(this.textBoxClassValue);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 340);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sampling Control";
            // 
            // buttonClearTrainingSet
            // 
            this.buttonClearTrainingSet.FlatAppearance.BorderSize = 0;
            this.buttonClearTrainingSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearTrainingSet.Location = new System.Drawing.Point(6, 131);
            this.buttonClearTrainingSet.Name = "buttonClearTrainingSet";
            this.buttonClearTrainingSet.Size = new System.Drawing.Size(118, 23);
            this.buttonClearTrainingSet.TabIndex = 5;
            this.buttonClearTrainingSet.Text = "Clear Training Set";
            this.buttonClearTrainingSet.UseVisualStyleBackColor = true;
            this.buttonClearTrainingSet.Click += new System.EventHandler(this.buttonClearTrainingSet_Click);
            // 
            // labelSampleRate
            // 
            this.labelSampleRate.AutoSize = true;
            this.labelSampleRate.Location = new System.Drawing.Point(6, 62);
            this.labelSampleRate.Name = "labelSampleRate";
            this.labelSampleRate.Size = new System.Drawing.Size(63, 13);
            this.labelSampleRate.TabIndex = 4;
            this.labelSampleRate.Text = "Sample rate";
            // 
            // textBoxSampleRate
            // 
            this.textBoxSampleRate.Location = new System.Drawing.Point(6, 79);
            this.textBoxSampleRate.Name = "textBoxSampleRate";
            this.textBoxSampleRate.Size = new System.Drawing.Size(118, 20);
            this.textBoxSampleRate.TabIndex = 3;
            this.textBoxSampleRate.Text = "20";
            this.textBoxSampleRate.Leave += new System.EventHandler(this.textBoxSampleRate_Leave);
            // 
            // buttonUndo
            // 
            this.buttonUndo.FlatAppearance.BorderSize = 0;
            this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUndo.Location = new System.Drawing.Point(6, 107);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(118, 23);
            this.buttonUndo.TabIndex = 2;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // listBoxTrainData
            // 
            this.listBoxTrainData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxTrainData.FormattingEnabled = true;
            this.listBoxTrainData.Location = new System.Drawing.Point(6, 164);
            this.listBoxTrainData.Name = "listBoxTrainData";
            this.listBoxTrainData.Size = new System.Drawing.Size(118, 173);
            this.listBoxTrainData.TabIndex = 0;
            // 
            // textBoxClassValue
            // 
            this.textBoxClassValue.Location = new System.Drawing.Point(6, 37);
            this.textBoxClassValue.Name = "textBoxClassValue";
            this.textBoxClassValue.Size = new System.Drawing.Size(118, 20);
            this.textBoxClassValue.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class Value";
            // 
            // chartError
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX2.IsMarginVisible = false;
            chartArea1.Name = "ChartArea1";
            this.chartError.ChartAreas.Add(chartArea1);
            this.chartError.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartError.Legends.Add(legend1);
            this.chartError.Location = new System.Drawing.Point(0, 0);
            this.chartError.Name = "chartError";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Error";
            this.chartError.Series.Add(series1);
            this.chartError.Size = new System.Drawing.Size(561, 130);
            this.chartError.TabIndex = 4;
            this.chartError.Text = "chartError";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(729, 515);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Test";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chartResults);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelTest);
            this.splitContainer1.Size = new System.Drawing.Size(723, 509);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 0;
            // 
            // chartResults
            // 
            this.chartResults.BorderlineWidth = 0;
            chartArea2.AxisX.Crossing = 1.7976931348623157E+308D;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY2.Maximum = 1D;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea2);
            this.chartResults.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartResults.Legends.Add(legend2);
            this.chartResults.Location = new System.Drawing.Point(0, 0);
            this.chartResults.Name = "chartResults";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.SystemColors.ActiveCaption;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.MarkerBorderWidth = 0;
            series2.Name = "Probability";
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartResults.Series.Add(series2);
            this.chartResults.Size = new System.Drawing.Size(723, 137);
            this.chartResults.TabIndex = 0;
            this.chartResults.Text = "chart1";
            // 
            // panelTest
            // 
            this.panelTest.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelTest.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTest.Location = new System.Drawing.Point(0, 0);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(723, 368);
            this.panelTest.TabIndex = 0;
            this.panelTest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTest_MouseDown);
            this.panelTest.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTest_MouseMove);
            this.panelTest.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTest_MouseUp);
            this.panelTest.Resize += new System.EventHandler(this.panelTest_Resize);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBoxInfo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(729, 515);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxInfo.BackColor = System.Drawing.Color.White;
            this.richTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxInfo.Location = new System.Drawing.Point(6, 6);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.ReadOnly = true;
            this.richTextBoxInfo.Size = new System.Drawing.Size(311, 503);
            this.richTextBoxInfo.TabIndex = 0;
            this.richTextBoxInfo.Text = "";
            // 
            // saveTrainingDataDialog
            // 
            this.saveTrainingDataDialog.FileName = "trainingSet.txt";
            this.saveTrainingDataDialog.Filter = "txt files (*.txt)|*.txt";
            this.saveTrainingDataDialog.FilterIndex = 2;
            this.saveTrainingDataDialog.RestoreDirectory = true;
            // 
            // openFileDialogTrainingSet
            // 
            this.openFileDialogTrainingSet.FileName = "trainingSet.txt";
            // 
            // backgroundWorkerTrainer
            // 
            this.backgroundWorkerTrainer.WorkerReportsProgress = true;
            this.backgroundWorkerTrainer.WorkerSupportsCancellation = true;
            this.backgroundWorkerTrainer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTrain_DoWork);
            this.backgroundWorkerTrainer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTrain_ProgressChanged);
            this.backgroundWorkerTrainer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTrain_RunWorkerCompleted);
            // 
            // timerTraining
            // 
            this.timerTraining.Interval = 10;
            this.timerTraining.Tick += new System.EventHandler(this.timerTraining_Tick);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // GestureExtractorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(737, 541);
            this.Controls.Add(this.tabControlTrain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 580);
            this.Name = "GestureExtractorForm";
            this.Text = "Gesture Extractor";
            this.tabControlTrain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelTrainResults.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panelTrainControl.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.TabControl tabControlTrain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelTrainResults;
        private System.Windows.Forms.Panel panelTrainControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxClassValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.ListBox listBoxTrainData;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Button buttonLoadTrainingSet;
        private System.Windows.Forms.Button buttonSaveTrainingSet;
        private System.Windows.Forms.SaveFileDialog saveTrainingDataDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialogTrainingSet;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFixedEtha;
        private System.Windows.Forms.TextBox textBoxIter;
        private System.Windows.Forms.Label labelSampleRate;
        private System.Windows.Forms.TextBox textBoxSampleRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTopology;
        private System.Windows.Forms.Label labelTopology;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonStohastic;
        private System.Windows.Forms.RadioButton radioButtonMiniBatch;
        private System.Windows.Forms.RadioButton radioButtonBatch;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBoxEthaLinear;
        private System.Windows.Forms.CheckBox checkBoxParallel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxMiniBatchSize;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTrainer;
        private System.Windows.Forms.Button buttonStopTrain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxEthaTo;
        private System.Windows.Forms.TextBox textBoxEthaFrom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelTime;
        private System.Windows.Forms.ToolStripStatusLabel labelEtha;
        private System.Windows.Forms.ToolStripStatusLabel labelError;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button buttonClearTrainingSet;
        private System.Windows.Forms.Timer timerTraining;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

