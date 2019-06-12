namespace ClassLibrary
{
    public class Triangle
    {
        public Triangle(int a, int b, int c, double p, double s)
        {
            A = a;
            B = b;
            C = c;
            P = p;
            S = s;
        }

        public int A { get; set; }

        public int B { get; set; }

        public int C { get; set; }

        public double P { get; set; }

        public double S { get; set; }

        public override string ToString()
        {
            return $"A = {A}, B = {B}, C = {C}, S = {S:f3}, P = {P:f3}";
        }
    }
}
