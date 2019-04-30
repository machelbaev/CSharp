/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 2
*/

using System;
using System.Collections;

namespace Task02
{
    public class Fibbonacci
    {
        public IEnumerable nextMemb(int limit)
        {
            int s = 1, n = 0;
            int t;
            for (int i = 0; i < limit; i++)
            {
                t = s + n;
                s = n;
                yield return n = t;
            }
        }
    }

    public class TriangleNums
    {
        public IEnumerable nextMemb(int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                yield return 1 * i * (i + 1) / 2;
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

                Fibbonacci fibbonacci = new Fibbonacci();
                TriangleNums triangleNums = new TriangleNums();

                Console.WriteLine("Fibbonacci: ");
                foreach (var item in fibbonacci.nextMemb(3))
                    Console.WriteLine(item);

                Console.WriteLine("Triangle numbers: ");
                foreach (var item in triangleNums.nextMemb(3))
                    Console.WriteLine(item);

                Console.WriteLine("Fibbonacci + triangle numbers: ");
                foreach (var fib in fibbonacci.nextMemb(3))
                    foreach (var tr in triangleNums.nextMemb(3))
                        Console.WriteLine((int)fib + (int)tr);

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


