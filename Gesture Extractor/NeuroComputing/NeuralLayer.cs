using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_Extractor.NeuroComputing
{
    public abstract class NeuralLayer : List<Neuron>
    {
        /// <summary>
        /// Trigger each neuron in current layer
        /// </summary>
        /// <param name="parallel">Performe in parallel manner</param>
        internal void ForwardPass(bool parallel)
        {
            if (!parallel)
            {
                foreach (Neuron n in this)
                    n.CalculateSaprk(); 
            }
            else Parallel.ForEach(this, c => c.CalculateSaprk());
        }

        /// <summary>
        /// Fully connect every neuron in this layer to all neurons to next layer
        /// </summary>
        /// <param name="nextNeuralLayer">Next neural layer</param>
        /// <param name="parallel">Performe in parallel manner</param>
        public void ConnectAll2NextLayer(HiddenNeuralLayer nextNeuralLayer, bool parallel)
        {
            if (!parallel)
            {
                foreach (Neuron n in this)
                    n.Connect2NextLayer(nextNeuralLayer); 
            }
            else Parallel.ForEach(this, c => c.Connect2NextLayer(nextNeuralLayer));
        }
    }
}