using System;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    public class Interval
    {
        public Interval(int right, int left)
        {
            if (right > left)
            {
                int temp = right;
                right = left;
                left = temp;
            }

            X1 = right;
            X2 = left;
        }

        public Interval(Interval interval)
        {
            X1 = interval.X1;
            X2 = interval.X2;
        }

        public int X1 { get; set; }

        public int X2 { get; set; }

        public int Length(int length)
        {
            return X2 - X1;
        }

        public override string ToString()
        {
            return $"min: {X1}, max: {X2}";
        }

        public static Interval operator +(Interval a, Interval b)
        {
            return new Interval(a.X1 + b.X1, a.X2 + b.X2);
        }

        public static Interval operator -(Interval a, Interval b)
        {
            return new Interval(a.X1 - b.X1, a.X2 - b.X2);
        }

        public static Interval operator *(Interval a, Interval b)
        {
            return new Interval(Math.Min(Math.Min(a.X1 * a.X2, a.X1 * b.X2), Math.Min(b.X1 * a.X2, b.X1 * b.X2)),
                Math.Max(Math.Max(a.X1 * a.X2, a.X1 * b.X2), Math.Max(b.X1 * a.X2, b.X1 * b.X2)));
        }

        public static Interval operator /(Interval a, Interval b)
        {
            try
            {
                return new Interval(Math.Min(Math.Min(a.X1 / a.X2, a.X1 / b.X2), Math.Min(b.X1 / a.X2, b.X1 / b.X2)),
                    Math.Max(Math.Max(a.X1 / a.X2, a.X1 / b.X2), Math.Max(b.X1 / a.X2, b.X1 / b.X2)));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                return new Interval(0, 0);
            }

        }
    }
    internal static class Program
    {
        public static void Main()
        {
            Interval a = new Interval(-5, 5);
            Interval b = new Interval(0, -10);
            Console.WriteLine(a / b);
            Console.WriteLine(a + b);
        }
    }
}