/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 4
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Task04
{
    public class RandomCollection : IEnumerable<int>
    {
        int n;

        public RandomCollection(int n)
        {
            this.n = n;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new RandomEnumerator(n);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal class RandomEnumerator : IEnumerator<int>
    {
        private int n, pos = -1;
        private int[] arr;
        static Random rnd = new Random();

        public RandomEnumerator(int n)
        {
            this.n = n;
            arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(-50, 51);
            }
        }

        public int Current
        {
            get
            {
                return arr[pos];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (pos < n - 1)
            {
                pos++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            pos = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                foreach (var item in new RandomCollection(10))
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


