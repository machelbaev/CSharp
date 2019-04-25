/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task:
*/

using System;

namespace Task06
{
    public class Polynomial2
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="a">coefficient</param>
        /// <param name="b">coefficient</param>
        /// <param name="c">coefficient</param>
        public Polynomial2(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// constructor which copy values from another class
        /// </summary>
        /// <param name="polinomial"></param>
        public Polynomial2(Polynomial2 polinomial)
        {
            A = polinomial.A;
            B = polinomial.B;
            C = polinomial.C;
        }

        /// <summary>
        /// coefficient a
        /// </summary>
        double a;

        /// <summary>
        /// property for coefficient a
        /// </summary>
        public double A
        {
            set
            {
                if (value == 0)
                    throw new ArgumentException("Coefficient 'a' can't be 0!");
                a = value;
            }
            get => a;
        }

        /// <summary>
        /// coefficient b
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// coefficient c
        /// </summary>
        public double C { get; set; }

        /// <summary>
        /// Calculates the value in x
        /// </summary>
        /// <param name="x">number</param>
        /// <returns>value in x</returns>
        public double Value(double x)
        {
            return A * x * x + B * x + C;
        }

        public static Polynomial2 operator +(Polynomial2 a, Polynomial2 b)
        {
            return new Polynomial2(a.A + b.A, a.B + b.B, a.C + b.C);
        }

        public static Polynomial2 operator -(Polynomial2 a, Polynomial2 b)
        {
            return new Polynomial2(a.A - b.A, a.B - b.B, a.C - b.C);
        }

        public static Polynomial2 operator *(Polynomial2 a, double b)
        {
            return new Polynomial2(a.A * b, a.B * b, a.C * b);
        }

        public static Polynomial2 operator /(Polynomial2 a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return new Polynomial2(a.A / b, a.B / b, a.C / b);
        }

        /// <summary>
        /// override ToString() method
        /// </summary>
        /// <returns>polynomial</returns>
        public override string ToString()
        {
            return $"{A:f1}*x^2+{B:f1}*x+{C:f1}";
        }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                try
                {
                    Polynomial2 p1 = new Polynomial2(-2, 3, 5);
                    Polynomial2 p2 = new Polynomial2(p1);
                    p2.B = -2;
                    p2.C = 4;
                    Console.WriteLine($"Polynomial {p1} / 3 = {p1 / 3}");
                    Console.WriteLine($"Polynomial {p1} * 2 = {p1 * 2}");
                    Console.WriteLine($"Polynomial {p1} + polynomial {p2} = {p1 + p2}");
                    Console.WriteLine($"Polynomial {p1} - polynomial {p2} = {p1 - p2}");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


