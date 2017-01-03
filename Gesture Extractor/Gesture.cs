using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_Extractor
{
    class Gesture : List<Point>
    {
        public string ClassName { get; private set; }

        public Gesture(string className)
        {
            ClassName = className;
        }

        public Gesture()
        {

        }

        /// <summary>
        /// Translate all the points to the center
        /// </summary>
        /// <param name="original">Original gesture</param>
        /// <returns>Translated gesture</returns>
        public static Gesture Translate(Gesture original)
        {
            Gesture translated = new Gesture(original.ClassName);
            // Calculate arithmetic mean
            Point mean = new Point(0.0f, 0.0f);
            foreach (Point p in original)
            {
                mean += p;
            }
            mean = mean * (1 / (float)original.Count);

            foreach (Point p in original)
            {
                translated.Add(p - mean);
            }
            return translated;
        }

        /// <summary>
        /// Scale all the points to the [-1.0, 1.0] range
        /// </summary>
        /// <param name="original">Original gesture</param>
        /// <returns>Scaled gesture</returns>
        public static Gesture Scale(Gesture original)
        {
            Gesture scaled = new Gesture(original.ClassName);
            // Find maxX and maxY
            float maxX = 0.0f;
            float maxY = 0.0f;
            foreach (Point p in original)
            {
                if (maxX < Math.Abs(p.X))
                    maxX = Math.Abs(p.X);
                if (maxY < Math.Abs(p.Y))
                    maxY = Math.Abs(p.Y);
            }
            float max = maxX > maxY ? maxX : maxY;

            foreach (Point p in original)
            {
                scaled.Add(p * (1 / max));
            }
            return scaled;
        }

        /// <summary>
        /// Interpolate gesture to the M points
        /// </summary>
        /// <param name="original"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        public static Gesture Interpolate(Gesture original, int M)
        {
            Gesture interpolated = new Gesture(original.ClassName);
            // Calculate the length of points
            float D = original.Length();

            for (int k = 0; k < M; ++k)
            {
                float t = k * D / (M - 1);
                Point pTemp = original.Lerp(t);
                interpolated.Add(pTemp);
            }
            return interpolated;
        }

        // check later
        private Point Lerp(float t)
        {
            Point interpolatedPoint = new Point();

            float nextLength = 0.0f;

            for (int i = 1; i < this.Count; ++i)
            {
                int prevIndex = i - 1;
                int nextIndex = i;
                Point prev = this[prevIndex];
                Point next = this[nextIndex];
                float prevLength = nextLength;
                nextLength += (next - prev).EuclideanDistance();

                if (t <= nextLength)
                {
                    // interpolate
                    float alpha = (t - prevLength) / (nextLength - prevLength);
                    interpolatedPoint = prev * (1.0f - alpha) + next * (alpha);
                    break;
                }
            }

            return interpolatedPoint;
        }

        /// <summary>
        /// Calculate the lenght of the gesture. Sum of Euclidean distances between all points
        /// </summary>
        /// <returns>Sum of Euclidean distances between all points</returns>
        public float Length()
        {
            float length = 0.0f;
            for (int i = 1; i < this.Count; ++i)
            {
                Point pTemp = this[i - 1] - this[i];
                float pTempD = pTemp.EuclideanDistance();
                length += pTempD;
            }
            return length;
        }

        /// <summary>
        /// Prepare gesture data for Neural Network.
        /// </summary>
        /// <param name="original">Original gesture</param>
        /// <param name="M">Number of points to interpolate</param>
        /// <returns>Transformed gesture</returns>
        public static Gesture Transform(Gesture original, int M)
        {
            return Gesture.Scale(Gesture.Translate(Gesture.Interpolate(original, M)));
        }

        public Gesture Copy()
        {
            Gesture g = new Gesture(this.ClassName);
            foreach (Point p in this)
                g.Add(p.Copy());

            return g;
        }
    }
}
