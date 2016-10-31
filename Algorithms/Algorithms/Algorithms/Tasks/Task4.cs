using System;
using System.Collections.Generic;

//Counting sort

namespace Algorithms
{
    public static class Task4
    {
        public static void Func(int range, int size)
        {
            var sortedList = new SortedList<int, int>();
            var arr = new int[size];
            var rand = new Random();
            for (var i = 0; i < size; i++)
            {
                arr[i] = rand.Next(range);
                Console.Write(string.Format("{0}, ", arr[i]));

                if (sortedList.ContainsKey(arr[i]))
                    sortedList[arr[i]]++;
                else
                    sortedList.Add(arr[i], 1);
            }
            Console.WriteLine();
            Console.WriteLine("result: ");
            foreach(var lst in sortedList)
            {                
                for (var j = 0; j < lst.Value; j++)
                {
                    Console.Write(string.Format("{0}, ", lst.Key));
                }
            }
        }
    }
}