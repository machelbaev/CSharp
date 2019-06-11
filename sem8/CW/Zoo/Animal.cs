/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using System;

namespace Task
{
    [Serializable]
    public abstract class Animal : IVocal
    {
        public static event EventHandler onSound;

        public int Id { get; set; }

        private static int id = 1;

        public Animal(string name, bool isTakenCare) { Id = id++; }

        protected Animal()
        {
        }

        abstract public string Name { get; set; }

        abstract public bool IsTakenCare { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, name: {Name}, is taken care: {IsTakenCare}";
        }

        public void DoSound()
        {
            onSound?.Invoke(typeof(Animal), new EventArgs());
            onSound = null; //clear the event
        }
    }
}


