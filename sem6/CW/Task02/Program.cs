/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 2
*/

using System;
using System.Collections;

namespace Task02
{
    public class MyInt : IEnumerable, IEnumerator
    {
        public object Current
        {
            get
            {
                if (pos < arr.Length)
                    return arr[pos];
                throw new InvalidOperationException();
            }
        }

        int[] arr;
        int pos = -1;

        public MyInt(int[] arr)
        {
            this.arr = arr;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (pos < arr.Length - 1)
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

                int[] arr = { 3, 4, 2, 6, 8, 4, 7, 8 };
                MyInt myInt = new MyInt(arr);
                foreach (var item in myInt)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


