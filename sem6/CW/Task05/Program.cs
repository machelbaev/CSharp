/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 5
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Task05
{
    public class Guest
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Party
    {
        private List<Guest> _guestList;
        public Party()
        {
            _guestList = new List<Guest>();
        }
        public void AddGuest(Guest guest)
        {
            _guestList.Add(guest);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in _guestList)
            {
                yield return item;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                Party party = new Party();
                party.AddGuest(new Guest() { Age = 25, Name = "John" });
                party.AddGuest(new Guest() { Age = 24, Name = "Barbara" });
                party.AddGuest(new Guest() { Age = 24, Name = "Phil" });
                party.AddGuest(new Guest() { Age = 23, Name = "Fred" });
                party.AddGuest(new Guest() { Age = 26, Name = "Hannah" });
                party.AddGuest(new Guest() { Age = 27, Name = "Cindy" });
                foreach (Guest guest in party)
                {
                    Console.WriteLine(guest.Name);
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


