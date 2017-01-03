using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_Extractor.Utilities_
{
    class Obsolite
    {
        private void trainSaple()
        {
            List<int> t = new List<int>() { 2, 2, 1 };
            //NeuralNetwork NN = new NeuralNetwork(t, checkBoxParallel.Checked);
            List<double> trueValue0 = new List<double>() { 1 };
            List<double> trainingPoints0 = new List<double>() { 1, 0 };
            List<double> trueValue1 = new List<double>() { 1 };
            List<double> trainingPoints1 = new List<double>() { 0, 1 };
            List<double> trueValue2 = new List<double>() { 0 };
            List<double> trainingPoints2 = new List<double>() { -1, 0 };
            List<double> trueValue3 = new List<double>() { 0 };
            List<double> trainingPoints3 = new List<double>() { 0, -1 };
            Tuple<List<double>, List<double>> trainingExample0 = new Tuple<List<double>, List<double>>(trueValue0, trainingPoints0);
            Tuple<List<double>, List<double>> trainingExample1 = new Tuple<List<double>, List<double>>(trueValue1, trainingPoints1);
            Tuple<List<double>, List<double>> trainingExample2 = new Tuple<List<double>, List<double>>(trueValue2, trainingPoints2);
            Tuple<List<double>, List<double>> trainingExample3 = new Tuple<List<double>, List<double>>(trueValue3, trainingPoints3);
            List<Tuple<List<double>, List<double>>> trainingSet = new List<Tuple<List<double>, List<double>>>() { trainingExample0, trainingExample1, trainingExample2, trainingExample3 };


            //NN.Train(trainingSet, 1000, 0.1, chartError, labelError);
        }
    }
}
