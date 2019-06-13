/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using System;
using System.IO;
using System.Linq;
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

        static Animal[] Deserialize()
        {
            Animal[] animals = null;
            try
            {
                using (FileStream file = new FileStream(@"..\..\..\zooAnimal.ser", FileMode.Open))
                {
                    XmlSerializer deser = new XmlSerializer(typeof(Animal[]), new Type[] { typeof(Bird),
                    typeof(Mammal)});
                    animals = (Animal[])deser.Deserialize(file);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return animals;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                Zoo zoo = new Zoo(new System.Collections.Generic.List<Animal>(Deserialize()));
                var birdsWithParent = from animal in zoo.AnimalList
                                      where (animal is Bird) && (animal.IsTakenCare)
                                      select animal;
                Console.WriteLine("Birds who are taken care: ");
                foreach (var item in birdsWithParent)
                {
                    Console.WriteLine(item);
                }

                var mammalsWithoutParent = from animal in zoo.AnimalList
                                           where (animal is Mammal) && (!animal.IsTakenCare)
                                           select animal;
                Console.WriteLine("\nMammals who are not taken care: ");
                foreach (var item in mammalsWithoutParent)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


