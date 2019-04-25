using System;

namespace Task04
{
    public class Atom
    {
        public Atom(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public int Attempts { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Atom atom &&
                   X == atom.X &&
                   Y == atom.Y &&
                   Z == atom.Z;
        }

        public override int GetHashCode()
        {
            var hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Atom a, Atom b)
        {
            if (a.X == b.X && a.Y == b.Y && a.Z == b.Z)
                return true;
            return false;
        }

        public static bool operator !=(Atom a, Atom b)
        {
            if (a.X == b.X && a.Y == b.Y && a.Z == b.Z)
                return false;
            return true;
        }

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}, Z = {Z}, attempts = {Attempts}";
        }
    }

    class Program
    {
        static Random rnd = new Random();

        static int number = 1000;

        static void Main(string[] args)
        {
            Atom[] atoms = new Atom[number];
            for (int i = 0; i < atoms.Length; i++)
            {
                atoms[i] = new Atom(rnd.Next(11), rnd.Next(11), rnd.Next(11));
            }
            int count = 1;
            while (count < number)
            {
                for (int i = 0; i < count; i++)
                {
                    if (atoms[i] == atoms[count])
                    {
                        atoms[count].X = rnd.Next(10);
                        atoms[count].Y = rnd.Next(10);
                        atoms[count].Z = rnd.Next(10);
                        atoms[count].Attempts++;
                        count = 1;
                        break;
                    }
                }
                count++;
            }

            //display atoms
            foreach (var item in atoms)
                Console.WriteLine(item.ToString());
            Console.ReadKey();
        }
    }
}
