using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_Extractor.NeuroComputing
{
    public class HiddenNeuralLayer : NeuralLayer
    {
        /// <summary>
        /// Create hidden neural layer
        /// </summary>
        /// <param name="width">Number of neurons in layer</param>
        /// <param name="previousLayer">Previous layer to which the neurons are going to be connected</param>
        public HiddenNeuralLayer(int width, NeuralLayer previousLayer)
        {
            for (int i = 0; i < width; i++)
                this.Add(new HiddenNeuron(previousLayer));
        }

        /// <summary>
        /// Set true values for output neurons
        /// </summary>
        /// <param name="trueValues">True values</param>
        /// <param name="parallel">Performe in parallel manner</param>
        internal void SetTrueValues(List<double> trueValues, bool parallel = false)
        {
            if (trueValues.Count != this.Count) throw new Exception("Number of true values are not consistent with number of last layer");

            if (parallel)
                Parallel.For(0, this.Count, i => this[i].SetTrueValue(trueValues[i]));
            else
            {
                for (int i = 0; i < this.Count; i++)
                    this[i].SetTrueValue(trueValues[i]);
            }
        }

        /// <summary>
        /// Calculate the error in this neural layer
        /// </summary>
        /// <param name="parallel">Performe in parallel manner</param>
        public void CalculateDelta(bool parallel = false)
        {
            if (parallel) Parallel.ForEach(this.OfType<HiddenNeuron>(), n => n.CalculateDelta());
            else
	        {
                foreach (HiddenNeuron n in this)
                    n.CalculateDelta();
            }
        }

        /// <summary>
        /// One pass back propagate
        /// </summary>
        /// <param name="parallel">Performe in parallel manner</param>
        internal void BackPropagate(bool parallel = false)
        {
            if (parallel) Parallel.ForEach(this.OfType<HiddenNeuron>(), n => n.LearnStep());
            else
            {
                foreach (HiddenNeuron n in this)
                    n.LearnStep(); 
            }
        }

        /// <summary>
        /// Update Weights in Neural Layer
        /// </summary>
        /// <param name="theta">Learning rate parameter</param>
        /// <param name="parallel">Perform in parallel processes</param>
        internal void UpdateWeights(double theta, bool parallel = false)
        {
            if (parallel) Parallel.ForEach(this.OfType<HiddenNeuron>(), n => n.Learn(theta));
            else
            {
                foreach (HiddenNeuron n in this)
                    n.Learn(theta); 
            }
        }
    }
}
