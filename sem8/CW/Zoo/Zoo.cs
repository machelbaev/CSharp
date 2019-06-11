/*
 Student: Chelbaev Mikhail
 Group: BPI182_2
*/

using System;
using System.Collections.Generic;

namespace Task
{
    public class Zoo
    {
        List<Animal> list;

        public Zoo(List<Animal> list)
        {
            this.list = list;
        }

        public IEnumerator<Animal> GetEnumerator()
        {
            Animal[] arr = list.ToArray();
            Array.Sort(arr, (x, y) =>
            {
                return x.Name.Length.CompareTo(y.Name.Length);
            });
            foreach (var item in arr)
            {
                yield return item;
            }
        }
    }
}


