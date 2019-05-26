/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 var: 2
*/

using System;
using System.Collections.Generic;

namespace Task
{
    public class Candidate
    {
        public string Surname { get; set; }

        Tester tester;

        Quiz<string, int> quiz;

        public Candidate(string surname, Tester tester)
        {
            Surname = surname;
            this.tester = tester ?? throw new ArgumentNullException();
            tester.StartTest += GetQuestionsList;
            tester.RegisterCandidateAnswers += GenerateAnswers;
            quiz = new Quiz<string, int>();
        }

        static Random rnd = new Random();

        private void GenerateAnswers(object sender, EventArgs e)
        {
            List<int> answers = new List<int>();
            for (int i = 0; i < quiz.QuizQuestions.Count; ++i)
            {
                answers.Add(rnd.Next(-5, 6));
            }
            CandidateAnswers candidate = new CandidateAnswers(Surname, answers, 0);
            tester.CandidateAnswersList.Add(candidate);
        }

        private void GetQuestionsList(object sender, StartQuizEventArgs e)
        {
            for (int i = 0; i < e.quiz.QuizQuestions.Count; i++)
            {
                quiz.QuizQuestions.Add(e.quiz.QuizQuestions[i]);
            }
        }
    }
}


