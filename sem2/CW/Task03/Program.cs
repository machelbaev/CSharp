/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task03: 
*/

using System;

namespace Task03
{
    class Program
    {
        /// <summary>
        /// Method for getting variable from user
        /// </summary>
        /// <param name="message">message to the user</param>
        /// <param name="minValue">minimum available value</param>
        /// <param name="maxValue">maximum available value</param>
        public static int Input(string message, int minValue, int maxValue)
        {
            int n;
            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out n) && n >= minValue && n <= maxValue)
                    break;
                Console.WriteLine("You entered invalid value!");
            } while (true);
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
