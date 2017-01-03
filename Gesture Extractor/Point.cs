using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesture_Extractor
{
    public class Point
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Point()
        {
            X = 0.0f;
            Y = 0.0f;
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public override string ToString()
        {
            return "{" + X.ToString() + ":" + Y.ToString() + "}";
        }

        public float EuclideanDistance()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point operator *(Point p1, float scalar)
        {
            return new Point(p1.X * scalar, p1.Y * scalar);
        }

        public Point Copy()
        {
            return new Point(this);
        }
    }
}
