using System;

namespace ClassLibrary
{
    [Serializable]
    public class Street
    {
        public Street(string name, int[] houses)
        {
            Name = name;
            Houses = houses;
        }

        public Street()
        {
        }

        public string Name { get; set; }

        public int[] Houses { get; set; }

        public static int operator ~(Street street)
        {
            return street.Houses.Length;
        }

        public static bool operator +(Street street)
        {
            if (Array.IndexOf(street.Houses, 7) == -1)
                return false;
            return true;
        }

        public override string ToString()
        {
            string houses = string.Empty;
            foreach (var item in Houses)
            {
                houses += item + " ";
            }
            return $"Name: {Name}, Houses: {houses}";
        }
    }
}
