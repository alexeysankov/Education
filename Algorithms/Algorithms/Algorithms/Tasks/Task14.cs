using System;

namespace Algorithms
{
    //Отсортировать массив относительно числа n
    public class Task14
    {
        public static void Func(int[] arr, int n)
        {
            var a = 0;
            var b = arr.Length - 1;
            while (a != b && a < b)
            {
                if (arr[a] < n)
                    a++;
                if (arr[b] > n)
                    b--;
                if (arr[a] > n && arr[b] < n)
                {
                    var tmp = arr[a];
                    arr[a] = arr[b];
                    arr[b] = tmp;
                    a++;
                    b--;
                }
            }

            foreach (var item in arr)
            {
                Console.Write(string.Format("{0}, ", item));
            }
        }
    }
}