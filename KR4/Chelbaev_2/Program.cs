/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Var: 2
*/

using CWLibrary;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Generates english words
        /// </summary>
        /// <returns>englishs word</returns>
        public static string GenerateEN()
        {
            string s = string.Empty;
            for (int i = 0; i < rnd.Next(2, 11); i++)
            {
                s += (char)rnd.Next('a', 'z' + 1);
            }
            return s;
        }

        /// <summary>
        /// Generates rus words
        /// </summary>
        /// <returns>rus word</returns>
        public static string GenerateRU()
        {
            string s = string.Empty;
            for (int i = 0; i < rnd.Next(2, 11); i++)
            {
                s += (char)rnd.Next('а', 'я' + 1);
            }
            return s;
        }

        /// <summary>
        /// Creates the file
        /// </summary>
        /// <param name="path">file path</param>
        /// <param name="n">number of lines</param>
        public static void CreateFile(string path, int n)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                for (int i = 0; i < n; i++)
                {
                    writer.WriteLine(GenerateRU() + " " + GenerateEN());
                }
            }
        }

        /// <summary>
        /// Adds words
        /// </summary>
        /// <param name="dictionary">dictionary</param>
        /// <param name="path">file path</param>
        public static void AddWords(ref Dictionary dictionary, string path)
        {
            using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    dictionary.Add(words[0], words[1]);
                }
            }
        }

        /// <summary>
        /// Random instance
        /// </summary>
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int n = Input("Input number of words (from 1 to 100): ", 1, 100);
            try
            {
                CreateFile("dictionary.txt", n);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            Dictionary dictionary = new Dictionary(new List<Pair<string, string>>());
            AddWords(ref dictionary, "dictionary.txt");

            Dictionary dict2 = null;
            try
            {
                dictionary.MySerialize(@"out.bin");
                dict2 = Dictionary.MyDeserialize(@"out.bin");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Words in dictionary: ");
            foreach (var item in dict2)
            {
                Console.WriteLine(item);
            }

            int len = rnd.Next(2, 11);
            Console.WriteLine($"\nWords with selected length({len}): ");
            foreach (var item in dict2.Words(len))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}


