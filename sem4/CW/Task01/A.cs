/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
 Task: 1
*/

using System.Collections;

namespace Task01
{
    public class A
    {
        private string[] arr = { "раз ромашка ", "два ромашка ",
            "три ромашка ", "пять ромашка ", "шесть ромашка " };

        public IEnumerator GetEnumerator()
        {
            foreach (var item in arr)
                yield return item;
        }
    }
}


