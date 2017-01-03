using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_Extractor.NeuroComputing
{
    public class InputNeuralLayer : NeuralLayer
    {
        /// <summary>
        /// Create input neural layer
        /// </summary>
        /// <param name="width">Number of neurons in layer</param>
        public InputNeuralLayer(int width)
        {
            for(int i = 0; i < width; i++)
            {
                this.Add(new InputNeuron());
            }
        }
    }
}
