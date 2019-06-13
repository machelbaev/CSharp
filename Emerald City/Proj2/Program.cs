/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Task
{
    class Program
    {
        public static Street[] Deserialize(string path)
        {
            Street[] streets = null;
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Street[]));
                streets = (Street[])xml.Deserialize(file);
            }
            return streets;
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                string path = @"..\..\..\Emerald City\bin\Debug\out.ser";
                Street[] streets = null;
                try
                {
                    streets = Deserialize(path);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                var magicStreets = from item in streets
                                   where (~item % 2 == 1) && (+item)
                                   select item;
                if (magicStreets.Count() != 0)
                    foreach (var item in magicStreets)
                    {
                        Console.WriteLine(item);
                    }
                else
                    Console.WriteLine("There are no magic streets!");

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


