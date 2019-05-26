/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 var: 2
*/

using System;
using System.Collections.Generic;

namespace Task
{
    public class CandidateAnswers
    {
        int mark;

        public CandidateAnswers(string name, List<int> answers, int mark)
        {
            Name = name;
            Answers = answers;
            Mark = mark;
        }

        public string Name { get; set; }

        public List<int> Answers { get; set; }

        public int Mark
        {
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException();
                mark = value;
            }
            get => mark;
        }
    }
}


