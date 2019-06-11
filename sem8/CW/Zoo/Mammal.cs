/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using System;

namespace Task
{
    [Serializable]
    public class Mammal : Animal
    {
        public Mammal(int paws, string name, bool isTakenCare) : base(name, isTakenCare)
        {
            Name = name;
            Paws = paws;
            IsTakenCare = isTakenCare;
        }

        public Mammal()
        {
        }

        int paws;

        public override string Name { get; set; }

        public int Paws
        {
            set
            {
                if (value <= 20 && value >= 1)
                    paws = value;
                else
                    throw new ArgumentException();
            }
            get => paws;
        }

        public override bool IsTakenCare { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", number of paws: {Paws}";
        }

        public void MakeSound(object sender, EventArgs e)
        {
            Console.WriteLine("я млекопитающие, би-би-би");
        }
    }
}


