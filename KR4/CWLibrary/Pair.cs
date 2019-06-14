using System;
using System.Collections;

namespace CWLibrary
{
    [Serializable]
    public class Pair<T, U> : IComparable
    {
        /// <summary>
        /// item1
        /// </summary>
        T item1;

        /// <summary>
        /// item2
        /// </summary>
        U item2;

        /// <summary>
        /// item1
        /// </summary>
        public T Item1 { get => item1; set => item1 = value; }

        /// <summary>
        /// item2
        /// </summary>
        public U Item2 { get => item2; set => item2 = value; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item1">item1</param>
        /// <param name="item2">item2</param>
        public Pair(T item1, U item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        /// <summary>
        /// Compare 2 pairs
        /// </summary>
        /// <param name="obj">pair</param>
        /// <returns>value</returns>
        public int CompareTo(object obj)
        {
            Pair<T, U> pair = (Pair<T, U>)obj;
            return Comparer.Default.Compare(Item1, pair.Item1);
        }

        /// <summary>
        /// ToString() method override
        /// </summary>
        /// <returns>string which describes the items</returns>
        public override string ToString()
        {
            return $"item1 = {Item1}, item2 = {Item2}";
        }
    }
}
