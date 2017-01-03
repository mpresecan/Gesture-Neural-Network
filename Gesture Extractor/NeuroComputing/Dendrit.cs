using Gesture_Extractor.Utilities_;
using System;
using System.Collections.Generic;

namespace Gesture_Extractor.NeuroComputing
{
    public class Dendrit
    {
        private HiddenNeuron parentNeuron;
        private double sumSteps;
        private int stepsCount;
        
        /// <summary>
        /// "Left" neighbour Neuron in previous layer
        /// </summary>
        public Neuron ConnectingNeuron { get; private set; }

        /// <summary>
        /// Weight of k-1 layer connection
        /// </summary>
        public double Weight { get; private set; }
        static private Random rnd = new Random();

        /// <summary>
        /// Create Dendrit conection
        /// </summary>
        /// <param name="previousNeuron">Previous (left) neighbour neuron</param>
        /// <param name="parentNeuron">Parent (current) neruon</param>
        public Dendrit(Neuron previousNeuron, HiddenNeuron parentNeuron)
        {
            // Initialize the random Gaussian Value
            Weight = rnd.NextDouble() * 2 - 1;
            //Weight = 0;
            this.ConnectingNeuron = previousNeuron;
            this.parentNeuron = parentNeuron;
            sumSteps = 0;
            stepsCount = 0;
        }
        /// <summary>
        /// Simulate spark conection between previous and current neuron
        /// </summary>
        /// <returns>Connectivity value</returns>
        public double Spark()
        {
            return Weight * ConnectingNeuron.SparkAxom();
        }


        /// <summary>
        /// Learn from previous neuron and this neurons error
        /// </summary>
        public void LearnStep()
        {
            sumSteps += ConnectingNeuron.SparkAxom() * parentNeuron.GetDeltaK();
            stepsCount++;
        }

        /// <summary>
        /// Update weight for this dendrit
        /// </summary>
        /// <param name="etha">The effect of the correction</param>
        internal void Learn(double etha)
        {
            double m = Weight + etha *  sumSteps / stepsCount;
            Weight = m;
            resetLearning();
        }

        /// <summary>
        /// Reset the counters
        /// </summary>
        private void resetLearning()
        {
            sumSteps = 0;
            stepsCount = 0;
        }

        public override string ToString()
        {
            return Weight.ToString();
        }
    }
}