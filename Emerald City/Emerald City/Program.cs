/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

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

        public static List<Street> ReadFile(string path)
        {
            List<Street> streets = new List<Street>();
            Encoding encoding = Encoding.Default;
            var text = File.ReadAllLines(path, encoding);
            foreach (var line in text)
            {
                string[] items = line.Split(' ');
                if (items.Length < 2)
                    throw new ArgumentException();
                List<int> houses = new List<int>();
                for (int i = 1; i < items.Length; i++)
                {
                    houses.Add(int.Parse(items[i]));
                }
                streets.Add(new Street(items[0], houses.ToArray()));
            }
            return streets;
        }

        public static List<Street> CreateStreats(int n)
        {
            List<Street> streets = new List<Street>();
            for (int i = 0; i < n; i++)
            {
                int numberOfHouses = rnd.Next(1, 11);
                int[] houses = new int[numberOfHouses];
                for (int j = 0; j < numberOfHouses; j++)
                {
                    houses[j] = rnd.Next(1, 101);
                }
                streets.Add(new Street(GenerateName(), houses));
            }
            return streets;
        }

        public static string GenerateName()
        {
            string name = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                name += (char)rnd.Next('a', 'z' + 1);
            }
            return name;
        }

        public static void Serialize(string path, Street[] streets)
        {
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Street[]));
                xml.Serialize(file, streets);
            }
        }

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                int n = Input("Input number of houses (from 1 to 100): ", 1, 100);
                List<Street> streets = new List<Street>();
                try
                {
                    streets = ReadFile("data.txt");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (n > streets.Count)
                    streets.AddRange(CreateStreats(n - streets.Count));

                foreach (var item in streets)
                {
                    Console.WriteLine(item);
                }
                try
                {
                    Serialize("out.ser", streets.ToArray());
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


