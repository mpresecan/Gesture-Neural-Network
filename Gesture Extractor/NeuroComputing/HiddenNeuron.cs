using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gesture_Extractor.Utilities_;
using System.Collections;

namespace Gesture_Extractor.NeuroComputing
{
    /// <summary>
    /// Hidden neuron, but also can be output neuron
    /// </summary>
    public class HiddenNeuron : Neuron
    {
        /// <summary>
        /// Connections to previous neurons
        /// </summary>
        public List<Dendrit> Dendrits;
        
        /// <summary>
        /// Free weight element
        /// </summary>
        private double bias;
       
        /// <summary>
        /// Back propagated Error for this neuron
        /// </summary>
        protected double Delta { get; private set; }

        private double biasSum;
        private double biasSumCount;

        /// <summary>
        /// Creating neuron in hiden, or output layer
        /// </summary>
        /// <param name="prevLayer"></param>
        /// <param name="nextLayer"></param>
        public HiddenNeuron(NeuralLayer prevLayer)
        {
            Dendrits = new List<Dendrit>();
            foreach (Neuron prevNeuron in prevLayer)
            {
                Dendrits.Add(new Dendrit(prevNeuron, this));
            }

            bias = 0;
            resetLearning();
        }

        /// <summary>
        /// Return calculated value of neuron
        /// </summary>
        /// <returns>Sum all weights * PreviousNeuron + bias</returns>
        public override void CalculateSaprk()
        {
            double net = 0;
            foreach (Dendrit dendrit in Dendrits)
            {
                double m = dendrit.Spark();
                net += m;
            }
            net += bias;
            base.AxomValue = Neuron.SigmoidFunction(net);
        }

        /// <summary>
        /// Get calculated error from this neuron
        /// </summary>
        /// <returns>Error - delta</returns>
        internal double GetDeltaK()
        {
            return Delta;
        }

        /// <summary>
        /// Calculate the error for current training example
        /// </summary>
        internal void LearnStep()
        {
            foreach (Dendrit d in Dendrits)
                d.LearnStep();
            
            // do biases
            biasSum += Delta;
            biasSumCount++;
        }

        /// <summary>
        /// Update weights in dendrits and update bias weights
        /// </summary>
        /// <param name="theta">The effect of the correction</param>
        internal void Learn(double theta)
        {
            foreach (Dendrit d in Dendrits)
                d.Learn(theta);

            bias = bias + theta * biasSum / biasSumCount;
            resetLearning();
        }

        /// <summary>
        /// Calculate the error for current neuron
        /// </summary>
        public void CalculateDelta()
        {
            // if it is a output neuron
            if (NextNeighbors == null)
                Delta = AxomValue * (1 - AxomValue) * (TrueValue - AxomValue);
            else
                Delta = AxomValue * (1 - AxomValue) * connectivityWeightSum();
        }

        /// <summary>
        /// Sum all weights between current neuron and next neuron, times delta of next neuron
        /// </summary>
        /// <returns>Sum of Weights</returns>
        private double connectivityWeightSum()
        {
            double sumOfWeights = 0;
            foreach (HiddenNeuron n in NextNeighbors)
                sumOfWeights += n.GetDeltaK() * n.getWeightConnection(this);
            return sumOfWeights;
        }

        /// <summary>
        /// Get weight connection between current neuron and previous layer neighbour
        /// </summary>
        /// <param name="previousNeighbour">Neuron from previous neural layer</param>
        /// <returns>Weight</returns>
        private double getWeightConnection(HiddenNeuron previousNeighbour)
        {
            foreach (Dendrit d in Dendrits)
            {
                if (d.ConnectingNeuron == previousNeighbour) return d.Weight; //check this, this might be a problem later
            }
            throw new Exception("You coudnt connect layers");
        }

        /// <summary>
        /// Reset biasSum and biasSumCount to zero
        /// </summary>
        private void resetLearning()
        {
            biasSum = 0;
            biasSumCount = 0;
        }

        public override string ToString()
        {
            return "{AV: " + AxomValue.ToString() + ", D: " + Delta.ToString() + "}";
        }
    }
}
