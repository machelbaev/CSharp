/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 var: 2
*/

using System.Collections.Generic;

namespace Task
{
    public class Quiz<U, T> where U : class
                            where T : struct
    {
        public Quiz()
        {
            QuizAnswers = new List<T>();

            QuizQuestions = new List<U>();
        }

        public List<U> QuizQuestions { get; set; }

        public List<T> QuizAnswers { get; set; }
    }
}


