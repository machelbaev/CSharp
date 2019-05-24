/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 3
*/

using System;
using System.Collections;

namespace Task03
{
    class ArithmeticProgression
    {
        int a;
        int d;

        public ArithmeticProgression(int a, int d)
        {
            this.a = a;
            this.d = d;
        }

        public IEnumerator GetEnumerator()
        {
            return Progression(10).GetEnumerator();
        }

        public IEnumerable Progression(int n)
        {
            int copyA = a;
            int copyD = d;
            for (int i = 0; i < n; i++)
            {
                yield return copyA;
                checked
                {
                    copyA += copyD;
                }
            }
        }
    }

    class Program
    {
        /// <summary>
        /// Method for getting variables from user
        /// </summary>
        /// <param name="message">message to the user</param>
        /// <param name="minValue">maximum available value</param>
        /// <param name="maxValue">minimum available value</param>
        public static int Input(string message, int minValue, int maxValue)
        {
            int n;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out n) && n <= maxValue && n >= minValue)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You entered invalid value!");
                }
            }
            return n;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                int a = Input("Input a: ", -100000, 100000);
                int d = Input("Input d: ", -100000, 100000);
                int n = Input("Input n: ", 0, 100000);

                ArithmeticProgression arithmeticProgression = new ArithmeticProgression(a, d);
                try
                {
                    foreach (int x in arithmeticProgression.Progression(n))
                    {
                        Console.WriteLine(x + " ");
                    }
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


