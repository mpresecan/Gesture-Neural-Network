using Gesture_Extractor.Utilities_;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gesture_Extractor.NeuroComputing
{
    public abstract class Neuron
    {
        public abstract void CalculateSaprk(); // calculate the neuron function

        /// <summary>
        /// It is a Y_i
        /// </summary>
        protected double AxomValue;

        /// <summary>
        /// Next Neighbors, or next neural layer
        /// </summary>
        protected HiddenNeuralLayer NextNeighbors;
        protected double TrueValue { get; private set; }

        /// <summary>
        /// Spark Axom, get the calculated value
        /// </summary>
        /// <returns></returns>
        public double SparkAxom()
        {
            return AxomValue;
        }

        /// <summary>
        /// Sigmoid Function
        /// </summary>
        /// <param name="net">NET value</param>
        /// <returns>Sigmoid Function result</returns>
        protected static double SigmoidFunction(double net)
        {
            double m = Math.Exp(-net);
            double r = Math.Pow(1 + m, -1);
            return r;
        }

        /// <summary>
        /// Connect this neuron to next neural layer
        /// </summary>
        /// <param name="nextNeuralLayer">Nexxt neural layer</param>
        public void Connect2NextLayer(HiddenNeuralLayer nextNeuralLayer)
        {
            NextNeighbors = nextNeuralLayer;
        }

        /// <summary>
        /// Set true Value for neuron of the last neural layer. Needed for backpropagation
        /// </summary>
        /// <param name="t">True value</param>
        internal void SetTrueValue(double t)
        {
            TrueValue = t;
        }
    }
}
