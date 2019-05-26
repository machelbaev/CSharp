/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 var: 2
*/

namespace Task
{
    public class StartQuizEventArgs
    {
        public Quiz<string, int> quiz;

        public StartQuizEventArgs(Quiz<string, int> quiz)
        {
            this.quiz = quiz;
        }
    }
}