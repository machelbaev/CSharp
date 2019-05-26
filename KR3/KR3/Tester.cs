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
    public class Tester
    {
        string Department { get; set; }

        Quiz<string, int> quiz;

        List<CandidateAnswers> candidateAnswers;

        public List<CandidateAnswers> CandidateAnswersList
        {
            get => candidateAnswers;
            set => candidateAnswers = value;
        }

        public Tester(string department, string inputFile)
        {
            Department = department;
            quiz = new Quiz<string, int>();
            GenerateQuiz(inputFile);
            CandidateAnswersList = new List<CandidateAnswers>();
        }

        public event EventHandler<StartQuizEventArgs> StartTest;

        public event EventHandler RegisterCandidateAnswers;

        public void GenerateQuiz(string path)
        {
            using (StreamReader streamReader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] arr = line.Split(';');
                    if (arr.Length < 2)
                        throw new ArgumentException();
                    quiz.QuizQuestions.Add(arr[0]);
                    if (!int.TryParse(arr[1], out int ans))
                        throw new ArgumentException();
                    quiz.QuizAnswers.Add(ans);
                }
            };
        }

        public void CheckCandidateAnswers()
        {
            for (int i = 0; i < CandidateAnswersList.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < quiz.QuizAnswers.Count; j++)
                {
                    if (CandidateAnswersList[i].Answers[j] == quiz.QuizAnswers[j])
                        ++count;

                }
                CandidateAnswersList[i].Mark = (count * 100) / quiz.QuizAnswers.Count;
            }
        }

        public void PrintExamResults(string path)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
            {
                CheckCandidateAnswers();
                for (int i = 0; i < CandidateAnswersList.Count; ++i)
                {
                    writer.WriteLine(CandidateAnswersList[i].Name + " : " + CandidateAnswersList[i].Mark);
                }
            }
        }

        public void OnStartQuiz()
        {
            StartTest?.Invoke(this, new StartQuizEventArgs(quiz));
        }

        public void OnRegisterCandidateAnswers()
        {
            RegisterCandidateAnswers?.Invoke(this, new EventArgs());
        }
    }
}


