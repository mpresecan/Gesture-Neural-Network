using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_Extractor.NeuroComputing
{
    /// <summary>
    /// Place holder for input values
    /// </summary>
    public class InputNeuron : Neuron
    {
        private double inputValue;

        /// <summary>
        /// Setup input to neuron
        /// </summary>
        /// <param name="inputValue"></param>
        public void SetupInput(double inputVal)
        {
            inputValue = inputVal;
        }

        /// <summary>
        /// Prepare the value for Spark Axom
        /// </summary>
        public override void CalculateSaprk()
        {
            base.AxomValue = inputValue;
        }
    }
}
