/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 var: 2
*/

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

        static string input = "../../../quiz.txt";
        static string output = "../../../results.txt";
        static Random rnd = new Random();
        static string[] surnames = { "Petrov", "Ivanov", "Sidorov" };

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                try
                {
                    //fill file with questions and answers
                    using (StreamWriter writer = new StreamWriter(new FileStream(input, FileMode.Create)))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            writer.WriteLine("Are you kidding?; " + rnd.Next(-5, 6));
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Tester tester = new Tester("software engineering", input);
                int n = Input("Input number of candidates (from 1 to 100): ", 0, 100);
                List<Candidate> candidates = new List<Candidate>();
                for (int i = 0; i < n; i++)
                {
                    candidates.Add(new Candidate(surnames[rnd.Next(3)], tester));
                }

                try
                {
                    tester.OnStartQuiz();
                    tester.OnRegisterCandidateAnswers();
                    tester.PrintExamResults(output);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


