/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 4
*/

using System;
using System.Collections;

namespace Task04
{
    public class Evens
    {
        int Nmin, Nmax;
        public Evens(int mi, int ma)
        { 
            if (mi >= ma)
            {
                int temp = mi;
                mi = ma;
                ma = temp;
            }
            Nmin = mi; Nmax = ma;
        }
        public IEnumerator GetEnumerator()
        {
            for (int p = Nmin; p <= Nmax; p++)
            {
                if (p % 2 == 0)
                    yield return p;
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

                Evens evens = new Evens(-10, 10);
                foreach (var item in evens)
                    Console.WriteLine(item);

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


