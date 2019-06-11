/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Generates the names
        /// </summary>
        /// <param name="n">name length</param>
        /// <returns>name</returns>
        public static string GenerateName(int n)
        {
            string s = string.Empty;
            for (int i = 0; i < n; i++)
            {
                s += (char)rnd.Next('a', 'z' + 1);
            }
            return s;
        }

        /// <summary>
        /// Generates the "is taken care" value
        /// </summary>
        /// <returns>value</returns>
        public static bool GenerateBool()
        {
            bool res = false;
            if (rnd.Next(1, 101) <= 40)
                res = true;
            return res;
        }

        /// <summary>
        /// Serializes into file
        /// </summary>
        /// <param name="animal">array of animals</param>
        public static void Serialize(Animal[] animal)
        {
            using (FileStream file = new FileStream(@"..\..\..\zooAnimal.ser", FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Animal[]), new Type[] { typeof(Bird),
                typeof(Mammal)});
                xmlSerializer.Serialize(file, animal);
            }
        }

        /// <summary>
        /// Instance of Random class
        /// </summary>
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                int n = Input("Input number of animals: ", 1, 100);
                List<Animal> list = new List<Animal>();
                for (int i = 0; i < n; i++)
                {
                    try
                    {
                        int num = rnd.Next(0, 2);
                        if (num == 0)
                        {
                            list.Add(new Mammal(rnd.Next(-10, 121), GenerateName(rnd.Next(4, 11)), GenerateBool()));
                            Animal.onSound += ((Mammal)list[i]).MakeSound;
                        }
                        else
                        {
                            list.Add(new Bird(rnd.Next(-10, 121), GenerateName(rnd.Next(4, 11)), GenerateBool()));
                            Animal.onSound += ((Bird)list[i]).MakeSound;
                        }
                    }
                    catch (ArgumentException)
                    {
                        i--;
                    }
                }
                Zoo zoo = new Zoo(list);
                foreach (var item in zoo)
                {
                    Console.WriteLine(item);
                }
                list[0].DoSound();

                try
                {
                    Serialize(list.ToArray());

                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

    }
}


