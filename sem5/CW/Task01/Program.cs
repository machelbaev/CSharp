/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 1
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Task01
{
    public class StringArray : IEnumerable<string[]>
    {
        string[] arr = { "third", "second", "first", "five" };
        List<Elem> elems = new List<Elem>();

        public IEnumerator<string[]> GetEnumerator()
        {
            foreach (var item in arr)
            {
                bool flag = false;
                foreach (var elem in elems)
                {
                    if (elem.letter == item[0])
                    {
                        flag = true;
                        elem.list.Add(item);
                        break;
                    }
                }
                if (!flag)
                {
                    elems.Add(new Elem(item[0], item));
                }
            }
            Elem[] copy = elems.ToArray();
            Array.Sort(copy);
            foreach (var item in copy)
            {
                yield return item.list.ToArray();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new Exception();
        }

        class Elem : IComparable<Elem>
        {
            public char letter;
            public List<string> list;

            public Elem(char letter, string elem)
            {
                this.letter = letter;
                list = new List<string>();
                list.Add(elem);
            }

            public int CompareTo(Elem other)
            {
                return list[0].CompareTo(other.list[0]);
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

                var a = new StringArray();

                foreach (var item in a)
                {
                    foreach (var elem in item)
                    {
                        Console.Write(elem + " ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


