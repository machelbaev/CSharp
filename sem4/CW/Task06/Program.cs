/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 6
*/

using System;
using System.Collections;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                FileLines source = new FileLines(@"..\..\Program.cs");
                foreach (var item in source)
                    Console.WriteLine(item);

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


