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
        public List<Animal> AnimalList { get; set; }

        public Zoo(List<Animal> list)
        {
            AnimalList = list;
        }

        public IEnumerator<Animal> GetEnumerator()
        {
            Animal[] arr = AnimalList.ToArray();
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


