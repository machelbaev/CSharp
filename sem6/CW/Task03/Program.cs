/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 3
*/

using System;
using System.Collections;

namespace Task03
{
    public class Alphabet : IEnumerable
    {
        char[] letters;

        public Alphabet()
        {
            char[] arr = new char[26];
            int pos = 0;
            for (int i = (int)'A'; i < (int)('Z' + 1); i++)
            {
                arr[pos] = (char)i;
                pos++;
            }
            letters = new char[26];
            letters[0] = 'A';
            for (int i = 2; i < letters.Length; i += 2)
            {
                letters[i - 1] = arr[i];
            }
            for (int i = 1; i < letters.Length - 1; i += 2)
            {
                letters[i + 1] = arr[i];
            }
            letters[25] = 'Z';
        }

        public IEnumerator GetEnumerator()
        {
            return new AlphabetEnumerator(letters);
        }
    }

    class AlphabetEnumerator : IEnumerator
    {
        public object Current
        {
            get
            {
                return letters[pos];
            }
        }

        char[] letters;

        int pos = -1;

        public AlphabetEnumerator(char[] letters)
        {
            this.letters = letters;
        }

        public bool MoveNext()
        {
            if (pos < letters.Length - 1)
            {
                pos++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            pos = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                foreach (var item in new Alphabet())
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine("Enter Esc to exit...");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}


