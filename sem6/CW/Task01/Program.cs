/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 1
*/

using System;
using System.Collections;

namespace Task01
{
    public class ArithmeticProgression
    {
        int a0, d, n;

        public ArithmeticProgression(int a0, int d, int n)
        {
            this.a0 = a0;
            this.d = d;
            this.n = n;
        }

        public IEnumerator GetEnumerator()
        {
            return new ArithmeticProgressionEnumerator(a0, d, n);
        }

        class ArithmeticProgressionEnumerator : IEnumerator
        {
            int a0, d, n, position = -1;

            public ArithmeticProgressionEnumerator(int a0, int d, int n)
            {
                this.a0 = a0;
                this.d = d;
                this.n = n;
            }

            public object Current
            {
                get
                {
                    if (position == -1 || position > n)
                        throw new InvalidOperationException();
                    return a0 + d * position;
                }
            }

            public bool MoveNext()
            {
                if (position < n - 1)
                {
                    position++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                ArithmeticProgression arithmeticProgression = new ArithmeticProgression(5, 5, 10);
                foreach (var item in arithmeticProgression)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


