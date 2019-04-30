/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 1
*/

using System;
using System.Collections;

namespace Task01
{

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                A a = new A();
                foreach (var item in a)
                    Console.WriteLine(item);

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


