using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_Extractor.Utilities_
{
    static class Utilities
    {
        public const double SmallEtha = 0.00001;
        public const double DefaultEtha = 0.01;
        public const int DefaultMiniBatchSize = 10;
        public const int DefaultSampleRate = 20;

        /// <summary>
        /// Random Gaussian Distribution
        /// </summary>
        /// <param name="rnd">Random number generator</param>
        /// <returns></returns>
        public static double RndGaussian(this Random rnd)
        {
            double u1 = rnd.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = rnd.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            float mean = 0.0f;
            float stdDev = 1.0f;
            return mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
        }

        internal static List<double> Gesture2Inputs(Gesture gesture)
        {
            List<double> inputs = new List<double>();
            foreach (Point p in gesture)
            {
                inputs.Add(p.X);
                inputs.Add(p.Y);
            }
            return inputs;
        }

        public static double SmallDouble()
        {
            return 0.000000000001;
        }

        public static bool IsNumber(this string text)
        {
            double n;
            return double.TryParse(text, out n);
        }

        /// <summary>
        /// Shuffle the element orders in list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static List<T> Shuffle<T>(this List<T> list)
        {
            Random rnd = new Random();
            List<T> newList = new List<T>();
            while(list.Count > 0)
            {
                int element = rnd.Next(list.Count - 1);
                newList.Add(list.ElementAt(element));
                list.RemoveAt(element);
            }
            return newList;
        }

    }
}
