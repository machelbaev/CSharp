/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 2
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Task02
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public double Mod
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }
        public bool Equals(Point other)
        {
            if (X == other.X & Y == other.Y)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return String.Format("x = {0}, y = {1}, mod = {2:G5}", X, Y, Mod);
        }
    }

    public class PointList : IEnumerable<Point>
    {
        // Закрытый список для хранения элементов последовательности:
        private List<Point> list;

        public PointList()
        {
            list = new List<Point>();
        }

        public IEnumerator<Point> GetEnumerator()
        {
            List<Point> points = new List<Point>();
            foreach (var item in list)
            {
                bool flag = false;
                foreach (var elem in points.ToArray())
                {
                    if (elem.Equals(item))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    points.Add(item);
            }
            foreach (var item in points)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        internal void Add(Point point)
        {
            list.Add(point);
        }
    }

    public class MainClass
    {
        static void Main(string[] args)
        {
            PointList set = new PointList();
            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(4, 5));
            set.Add(new Point(7, 1));
            set.Add(new Point(7, 2));
            set.Add(new Point(5, 2));
            set.Add(new Point(7, 2));
            Console.WriteLine("Список точек на плоскости:");
            foreach (Point p in set)
                Console.WriteLine(p.ToString());

            Console.ReadKey();
        }
    }
}



