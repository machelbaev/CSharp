using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CWLibrary
{
    [Serializable]
    public class Dictionary
    {
        /// <summary>
        /// language locale
        /// </summary>
        int locale;

        /// <summary>
        /// list of pairs
        /// </summary>
        List<Pair<string, string>> words;

        static Random rnd = new Random();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="words">list of pairs</param>
        public Dictionary(List<Pair<string, string>> words)
        {
            this.words = words;
            locale = rnd.Next(0, 2);
        }

        /// <summary>
        /// Adds pair in list
        /// </summary>
        /// <param name="pair"></param>
        public void Add(Pair<string, string> pair)
        {
            words.Add(pair);
        }

        /// <summary>
        /// Adds pair in list
        /// </summary>
        public void Add(string a, string b)
        {
            words.Add(new Pair<string, string>(a, b));
        }

        /// <summary>
        /// GetEnumerator()
        /// </summary>
        /// <returns>enumerator</returns>
        public IEnumerator<Pair<string, string>> GetEnumerator()
        {
            IOrderedEnumerable<Pair<string, string>> orderedWords;
            if (rnd.Next(0, 2) == 0)
            {
                orderedWords = from item in words
                               orderby item.Item1
                               select item;
            }
            else
            {
                orderedWords = from item in words
                               orderby item.Item2
                               select item;
            }
            foreach (var item in orderedWords)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Enumerates words 
        /// </summary>
        /// <param name="len">length</param>
        /// <returns>enumerable</returns>
        public IEnumerable<Pair<string, string>> Words(int len)
        {
            IOrderedEnumerable<Pair<string, string>> orderedWords;
            if (rnd.Next(0, 2) == 0)
            {
                orderedWords = from item in words
                               where item.Item1.Length == len
                               orderby item.Item1
                               select item;
            }
            else
            {
                orderedWords = from item in words
                               where item.Item2.Length == len
                               orderby item.Item2
                               select item;
            }
            foreach (var item in orderedWords)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Serializes current instance
        /// </summary>
        /// <param name="path">file path</param>
        public void MySerialize(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(file, this);
            }
        }

        /// <summary>
        /// Deserialize dictionary
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>Dictionary instance</returns>
        public static Dictionary MyDeserialize(string path)
        {
            Dictionary dictionary = null;
            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter binary = new BinaryFormatter();
                dictionary = (Dictionary)binary.Deserialize(file);
            }
            return dictionary;
        }
    }

}
