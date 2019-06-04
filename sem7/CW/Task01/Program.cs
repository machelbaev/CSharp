/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 1
*/

using System;

namespace Task01
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

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


