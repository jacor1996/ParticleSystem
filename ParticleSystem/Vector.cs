using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscsMFAK
{
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public void Limit(float topSpeed)
        {
            if (X > topSpeed)
            {
                X = topSpeed;
            }

            if (Y > topSpeed)
            {
                Y = topSpeed;
            }
        }

        public void Add(Vector v)
        {
            X = X + v.X;
            Y = Y + v.Y;
        }

        public void Subtract(Vector v)
        {
            X = X - v.X;
            Y = Y - v.Y;
        }

        public static Vector Subtract(Vector v, Vector u)
        {
            Vector vector = new Vector(v.X - u.X, v.Y - u.Y);
            return vector;
        }

        public void Multiply(float n)
        {
            X = X * n;
            Y = Y * n;
        }

        public void Divide(float n)
        {
            X = X / n;
            Y = Y / n;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public void Normalize()
        {
            float m = Magnitude();
            if (Math.Abs(m) > 0.001)
            {
                Divide(m);
            }
        }
    }
}
