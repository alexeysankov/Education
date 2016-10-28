using System;

namespace Algorithms
{
    //difference positions in sorted and unsorted arrays not exceed k
    public static class Task3
    {
        public static void Func(int[] arr, int k)
        {
            int temp;
            int min;

            Console.WriteLine("start:");
            foreach (var t in arr)
            {
                Console.Write($"{t}, ");
            }
            Console.WriteLine();
            Console.WriteLine();
            for (var i = 0; i < arr.Length - 1; i++)
            {
                min = i;
                for (var j = i + 1; (j < i + 1 + k) && (j < arr.Length); j++)
                {
                    if (arr[min] > arr[j])
                        min = j;
                }


                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }

                foreach (var t in arr)
                {
                    Console.Write($"{t}, ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("result:");
            foreach (var t in arr)
            {
                Console.Write($"{t}, ");
            }
        }
    }
}