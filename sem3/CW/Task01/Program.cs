using System;

namespace Task01
{
    internal class myComplex
    {
        public double Re { get; set; }

        public double Im { get; set; }

        public myComplex(double xre, double xim)
        {
            Re = xre;
            Im = xim;
        }

        public static myComplex operator --(myComplex mc)
        {
            mc.Re--;
            mc.Im--;
            return mc;
        }

        //public static myComplex operator ++(myComplex mc)
        //{ mc.re++; mc.im++; return mc; }
        public double Mod()
        {
            return Math.Abs(Re * Re + Im * Im);
        }

        public static bool operator true(myComplex f)
        {
            if (f.Mod() > 1.0) return true;
            return false;
        }

        public static bool operator false(myComplex f)
        {
            if (f.Mod() <= 1.0) return true;
            return false;
        }

        public static myComplex operator +(myComplex a, myComplex b)
        {
            return new myComplex(a.Re + b.Re, a.Im + b.Im);
        }

        public static myComplex operator -(myComplex a, myComplex b)
        {
            return new myComplex(a.Re - b.Re, a.Im - b.Im);
        }

        public static myComplex operator *(myComplex a, myComplex b)
        {
            return new myComplex(a.Re * b.Re - a.Im * b.Im, a.Im * b.Re + b.Im * a.Re);
        }

        public static myComplex operator /(myComplex a, myComplex b)
        {
            return new myComplex((a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im),
                (a.Re * b.Re - a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im));
        }
    }


    public class Program
    {
        private static void display(myComplex cs)
        {
            Console.WriteLine("real=" + cs.Re + ", image=" + cs.Im);
        }

        private static void Main()
        {
            var c1 = new myComplex(4, 3.3);
            Console.WriteLine("Модуль исходного комплексного числа = " +
                              c1.Mod());
            while (c1)
            {
                Console.Write("c1 => ");
                display(c1);
                c1--;
            }

            Console.WriteLine("Модуль полученного числа = " +
                              c1.Mod());
            Console.WriteLine("Число принадлежит кругу с радиусом 1.");
            Console.ReadLine();
        }
    }
}
