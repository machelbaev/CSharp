/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 var: 1
*/

using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task
{
    public class Register
    {
        public List<Triangle> Triangles;

        public Register()
        {
            Triangles = new List<Triangle>();
            ReadFromFile();
        }

        void ReadFromFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(@"..\..\..\Triangle.txt",
                    FileMode.Open)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] nums = line.Split(' ');
                        int.TryParse(nums[0], out int a);
                        int.TryParse(nums[1], out int b);
                        int.TryParse(nums[2], out int c);
                        double p = a + b + c;
                        double s = Math.Sqrt(p / 2 * (p / 2 - a) * (p / 2 - b) * (p / 2 - c));
                        Triangles.Add(new Triangle(a, b, c, p, s));
                    }
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
        }

        public IEnumerator<Triangle> GetEnumerator()
        {
            foreach (var item in Triangles)
            {
                yield return item;
            }
        }
    }

    class Program
    {
        /// <summary>
        /// Method for getting variables from user
        /// </summary>
        /// <param name="message">message to the user</param>
        public static int Input(string message)
        {
            int n;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out n))
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

                Register register = new Register();
                foreach (var item in register)
                {
                    Console.WriteLine(item);
                }

                var orderByPerim = from item in register.Triangles
                                   orderby item.P
                                   select item;
                Console.WriteLine("\nOrdered by perimeter: ");
                foreach (var item in orderByPerim)
                {
                    Console.WriteLine(item);
                }

                int n = Input("Input value: ");
                var task2 = from item in register.Triangles
                            where item.S / item.P > n
                            select item;
                Console.WriteLine("\nTriangles where the ratio of the area to the perimeter is greater than inputed" +
                    "value: ");
                foreach (var item in task2)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


