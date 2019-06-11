/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using System;

namespace Task
{
    [Serializable]
    public class Bird : Animal
    {
        int speed;

        public Bird()
        {
        }

        public Bird(int speed, string name, bool isTakenCare) : base(name, isTakenCare)
        {
            Speed = speed;
            Name = name;
            IsTakenCare = isTakenCare;
        }

        public int Speed
        {
            set
            {
                if (value >= 1 && value <= 100)
                    speed = value;
                else
                    throw new ArgumentException();
            }
            get => speed;
        }

        public override string Name { get; set; }

        public override bool IsTakenCare { get; set; }

        public void MakeSound(object sender, EventArgs e)
        {
            Console.WriteLine("я птичка, пип-пип-пип");
        }

        public override string ToString()
        {
            return base.ToString() + $", speed: {Speed}";
        }
    }
}


