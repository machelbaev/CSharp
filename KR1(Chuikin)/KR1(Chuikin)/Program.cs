/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task:
*/

using System;
using System.IO;

namespace Task
{
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

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                int n = Input("Input number of lines (from 1 to 100): ", 1, 100);
                int m = Input("Input number of max size of triangle side (from 1 to 1000): ", 1, 1000);
                try
                {
                    using (StreamWriter file = new StreamWriter(new FileStream(@"..\..\..\Triangle.txt",
                        FileMode.Create)))
                    {
                        for (int i = 0; i < n; i++)
                        {
                            while (true)
                            {
                                int a = rnd.Next(1, m + 1);
                                int b = rnd.Next(1, m + 1);
                                int c = rnd.Next(1, m + 1);
                                if (a < b + c && b < a + c && c < a + b)
                                {
                                    file.WriteLine($"{a} {b} {c}");
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }


                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


