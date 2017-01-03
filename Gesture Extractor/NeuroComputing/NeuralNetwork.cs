using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Gesture_Extractor.Utilities_;

namespace Gesture_Extractor.NeuroComputing
{
    public class NeuralNetwork : List<NeuralLayer>
    {
        /// <summary>
        /// Create neural network
        /// </summary>
        /// <param name="topology">Topology of neural network</param>
        public NeuralNetwork(List<int> topology, bool parallel = false)
        {
            this.Add(new InputNeuralLayer(topology[0]));
            for (int i = 1; i < topology.Count; i++)
            {
                this.Add(new HiddenNeuralLayer(topology[i], this[i - 1]));
            }
            // Connect all layers with the next layer
            for (int i = 0; i < topology.Count - 1; i++)
            {
                this[i].ConnectAll2NextLayer((HiddenNeuralLayer)this[i + 1], parallel);
            }
        }

        /// <summary>
        /// Setup inputs to neural network
        /// </summary>
        /// <param name="inputs"></param>
        private void setInputs(List<double> inputs)
        {
            if (inputs.Count != this.First().Count) throw new Exception("Inputs are not same dimmensions as the input layer");

            // For every neuron in layer setup the input value
            for (int i = 0; i < inputs.Count; i++)
                ((InputNeuron)this.First()[i]).SetupInput(inputs[i]);
        }

        /// <summary>
        /// Get output of neural network
        /// </summary>
        /// <returns>Axom values of all neuron in last neural layer</returns>
        private List<double> getOutputs()
        {
            List<double> outputs = new List<double>();
            foreach (Neuron n in this.Last())
                outputs.Add(n.SparkAxom());

            return outputs;
        }

        /// <summary>
        /// Calculate forward pass for given input
        /// </summary>
        /// <param name="inputs">Input feed in neural network</param>
        /// <param name="parallel">Performe in parallel manner</param>
        /// <returns>Output feed of neural network</returns>
        public List<double> ForwardPass(List<double> inputs, bool parallel = false)
        {
            // Protocol for Forward Pass:
            // Set inputs -> propagate the values through the networks -> get outputs
            
            setInputs(inputs);

            foreach (NeuralLayer nl in this)
                nl.ForwardPass(parallel);

            return getOutputs();
        }

        /// <summary>
        /// Performe one backward pass for one training example, sum all error across the network
        /// </summary>
        /// <param name="trueValues">One Hot Codded train example</param>
        /// <param name="parallel">Performe in parallel manner</param>
        public void BackwardPass(List<double> trueValues, bool parallel = false)
        {
            // protocol backwardPass:
            // SetTrueValues -> Calculate Deltas -> BackPropagateDeltas
            HiddenNeuralLayer hnl0 = (HiddenNeuralLayer)this.Last();
            hnl0.SetTrueValues(trueValues, parallel);

            for (int i = this.Count - 1; i >= 1; i--) // ignore first layer
            {
                HiddenNeuralLayer hnl = (HiddenNeuralLayer)this[i];
                hnl.CalculateDelta(parallel);
            }

            for (int i = this.Count - 1; i >= 1; i--) // ignore first layer
            {
                HiddenNeuralLayer hnl = (HiddenNeuralLayer)this[i];
                hnl.BackPropagate(parallel);
            }
        }

        /// <summary>
        /// Update Weights in whole neural network
        /// </summary>
        /// <param name="theta">Learning rate parameter</param>
        /// <param name="parallel">Performe in parallel manner</param>
        private void UpdateWeights(double theta, bool parallel = false)
        {
            for (int i = this.Count - 1; i >= 1; i--)
            {
                HiddenNeuralLayer hnl = (HiddenNeuralLayer)this[i];
                hnl.UpdateWeights(theta, parallel);
            }
        }

        /// <summary>
        /// Calculate Square Deviation from the calculated output and true output
        /// </summary>
        /// <param name="fpOut">Calculated or Forward Pass output</param>
        /// <param name="trueOut">True output</param>
        /// <returns>Sigma - Square Deviation</returns>
        private double calculateError(List<double> fpOut, List<double> trueOut)
        {
            double sumError = 0;
            for (int i = 0; i < fpOut.Count; i++)
            {
                sumError += Math.Pow(trueOut[i] - fpOut[i], 2);
            }
            return sumError;
        }

        /// <summary>
        /// Train Neural Network with Stohastic Backpropagation
        /// </summary>
        /// <param name="trainigSetReady">Training Set</param>
        /// <param name="i">Current iteration</param>
        /// <param name="fixedEtha">Fixed Etha Value</param>
        /// <param name="iter">Iteration period in linear interpolated etha</param>
        /// <param name="minEtha">Minimial value of etha</param>
        /// <param name="maxEtha">Maximal value of etha</param>
        /// <param name="parallel">Performe in parallel manner</param>
        /// <param name="bw">Background Worker - thread communication object</param>
        internal void TrainStohastic(List<Tuple<List<double>, List<double>>> trainigSetReady, int i, double fixedEtha = 0, int iter = 0, double minEtha = 0, double maxEtha = 0, bool parallel = false, BackgroundWorker bw = null)
        {
            double ethaCorrection = fixedEtha;

            if (fixedEtha == 0 && (iter == 0 || minEtha == 0 || maxEtha == 0)) throw new Exception("Not all linear etha change parameter had not been passed");
            else if (fixedEtha != 0 && (iter != 0 || minEtha != 0 || maxEtha != 0)) throw new Exception("Not all fixed etha parameter had not been passed");

            int initialI = i;

           

            while (true)
            {
                // protocol for training:
                // foreach training example:
                //  forwardpass
                //  backwardPass
                //  update values if (j % batch == 0)


                if (fixedEtha == 0)
                {
                    if ((i - initialI) < iter)
                        ethaCorrection = calculateLinearEtha(i, iter, maxEtha, minEtha, initialI);
                    else ethaCorrection = minEtha;
                }

                double sum = 0;
                for (int j = 0; j < trainigSetReady.Count; j++)
                {
                    List<double> fpOut = ForwardPass(trainigSetReady[j].Item2, parallel);
                    BackwardPass(trainigSetReady[j].Item1, parallel);
                    sum += calculateError(fpOut, trainigSetReady[j].Item1);

                    UpdateWeights(ethaCorrection);
                }

                double E = (1 / ((double)trainigSetReady.Count)) * sum;
                i++;

                if (bw != null)
                {
                    int percent = (int)Math.Round(((double)i / iter) * 100);
                    bw.ReportProgress(percent, new Report(E, i, ethaCorrection));
                    if (bw.CancellationPending)
                        return;
                }
            }
        }

        /// <summary>
        /// Train Neural Network with Mini Batch Backpropagation
        /// </summary>
        /// <param name="trainigSetReady">Training Set</param>
        /// <param name="i">Current iteration</param>
        /// <param name="miniBatchSize">Mini Batch Size</param>
        /// <param name="fixedEtha">Fixed Etha Value</param>
        /// <param name="iter">Iteration period in linear interpolated etha</param>
        /// <param name="minEtha">Minimial value of etha</param>
        /// <param name="maxEtha">Maximal value of etha</param>
        /// <param name="parallel">Performe in parallel manner</param>
        /// <param name="bw">Background Worker - thread communication object</param>
        internal void TrainMiniBatch(List<Tuple<List<double>, List<double>>> trainigSetReady, int i, int miniBatchSize, double fixedEtha = 0, int iter = 0, double minEtha = 0, double maxEtha = 0, bool parallel = false, BackgroundWorker bw = null)
        {
            double ethaCorrection = fixedEtha;

            if (fixedEtha == 0 && (iter == 0 || minEtha == 0 || maxEtha == 0)) throw new Exception("Not all linear etha change parameter had not been passed");
            else if (fixedEtha != 0 && (iter != 0 || minEtha != 0 || maxEtha != 0)) throw new Exception("Not all fixed etha parameter had not been passed");

            int initialI = i;

            while (true)
            {
                // protocol for training:
                // foreach training example:
                //  forwardpass
                //  backwardPass
                //  update values if (j % batch == 0)
                double sum = 0;

                if (fixedEtha == 0)
                {
                    if ((i - initialI) < iter)
                        ethaCorrection = calculateLinearEtha(i, iter, maxEtha, minEtha, initialI);
                    else ethaCorrection = minEtha;
                }


                //foreach (var trainingExample in trainigSetReady)
                for (int j = 0; j < trainigSetReady.Count; j++)
                {
                    List<double> fpOut = ForwardPass(trainigSetReady[j].Item2, parallel);
                    BackwardPass(trainigSetReady[j].Item1, parallel);
                    sum += calculateError(fpOut, trainigSetReady[j].Item1);

                    if(j % miniBatchSize == 0)
                        UpdateWeights(ethaCorrection);

                }
                trainigSetReady = trainigSetReady.Shuffle();
                

                double E = (1 / ((double)trainigSetReady.Count)) * sum;
                i++;

                if (bw != null)
                {
                    int percent = (int)Math.Round(((double)i / iter) * 100);
                    bw.ReportProgress(percent, new Report(E, i, ethaCorrection));
                    if (bw.CancellationPending)
                        return;
                }
            }
        }

        /// <summary>
        /// Train Neural Network with Full Batch Backpropagation
        /// </summary>
        /// <param name="trainigSetReady">Training Set</param>
        /// <param name="i">Current iteration</param>
        /// <param name="fixedEtha">Fixed Etha Value</param>
        /// <param name="iter">Iteration period in linear interpolated etha</param>
        /// <param name="minEtha">Minimial value of etha</param>
        /// <param name="maxEtha">Maximal value of etha</param>
        /// <param name="parallel">Performe in parallel manner</param>
        /// <param name="bw">Background Worker - thread communication object</param>
        internal void TrainBatch(List<Tuple<List<double>, List<double>>> trainigSetReady, int i, double fixedEtha = 0, int iter = 0, double minEtha=0, double maxEtha=0, bool parallel = false, BackgroundWorker bw = null)
        {
            double ethaCorrection = fixedEtha;

            if (fixedEtha == 0 && (iter == 0 || minEtha == 0 || maxEtha == 0)) throw new Exception("Not all linear etha change parameter had not been passed");
            else if (fixedEtha != 0 && (iter != 0 || minEtha != 0 || maxEtha != 0)) throw new Exception("Not all fixed etha parameter had not been passed");

            int initialI = i;

            while (true)
            {
                // protocol for training:
                // foreach training example:
                //  forwardpass
                //  backwardPass
                // update values
                double sum = 0;
                foreach (var trainingExample in trainigSetReady)
                {
                    List<double> fpOut = ForwardPass(trainingExample.Item2, parallel);
                    BackwardPass(trainingExample.Item1, parallel);
                    sum += calculateError(fpOut, trainingExample.Item1);
                }
                if (fixedEtha == 0)
                {
                    if ((i - initialI) < iter)
                        ethaCorrection = calculateLinearEtha(i, iter, maxEtha, minEtha, initialI);
                    else ethaCorrection = minEtha;
                }
                UpdateWeights(ethaCorrection);

                double E = (1 / ((double)trainigSetReady.Count)) * sum;
                i++;

                if (bw != null)
                {
                    int percent = (int)Math.Round(((double)i / iter) * 100);
                    bw.ReportProgress(percent, new Report(E, i, ethaCorrection));
                    if (bw.CancellationPending)
                        return;
                }
            }
        }

        /// <summary>
        /// Calculate the current etha value in linear manner
        /// </summary>
        /// <param name="i">Current iteration</param>
        /// <param name="iter">Total number of iterations</param>
        /// <param name="maxEtha">Maximal value of etha</param>
        /// <param name="minEtha">Minimal value of etha</param>
        /// <param name="initialI">i - shift</param>
        /// <returns>Linear interpolated etha</returns>
        private double calculateLinearEtha(int i, int iter, double maxEtha, double minEtha, int initialI)
        {
            // 1.0 the maximum of etha
            // 0.0001 the minimum of etha
            return (minEtha - maxEtha)/iter * (i - initialI) + 1;
        }
    }
}
