/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 5
*/

using System;
using System.Collections;

namespace Task05
{
    public class IterateCollection<T>
    {
        T[] collection;
        public IterateCollection(T[] collection)
        {
            this.collection = collection;
        }

        public IEnumerable Elements(int start)
        {
            for (int i = start; i < collection.Length; i++)
                yield return collection[i];
            for (int i = 0; i < start; i++)
                yield return collection[i];
        }

        public IEnumerator GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        public IEnumerator DirectOrder()
        {
            return GetEnumerator();
        }

        public IEnumerable ReverseOrder()
        {
            for (int i = collection.Length - 1; i > -1; i--)
                yield return collection[i];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                IterateCollection<int> collection = new IterateCollection<int>(array);
                //foreach(var item in collection.Elements(3))
                //{
                //    Console.WriteLine(item);
                //}
                foreach (var item in collection.ReverseOrder())
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


