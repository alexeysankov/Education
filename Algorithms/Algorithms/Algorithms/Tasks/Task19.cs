using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    //Determine if array contains two numbers having sum M (b) - Tree that adds up to zero
    public class Task19
    {
        public static void Func(int[] arr, int m)
        {
            var list = arr.ToList();
            list.Sort();
            foreach (var a in list)
            {
                Console.Write(string.Format("{0}, ", a));
            }
            Console.WriteLine();
            var i = 0;
            while (list[i] <= m/2)
            {
                var tmp = Find(list.ToArray(), m - list[i]);
                if (tmp != -1)
                    Console.WriteLine(string.Format("({0},{1})", i, tmp));
                i++;
            }
        }

        private static int Find(int[] arr, int num)
        {
            var start = 0;
            var end = arr.Length - 1;
            var result = -1;
            int mid;

            while ((end - start > 1) && result == -1)
            {
                mid = (end - start) / 2;
                if (num == arr[start])
                    result = start;
                if (num == arr[end])
                    result = end;
                if (num < arr[start + mid] && num > arr[start])
                    end = end - mid;
                else
                    start = start + mid;

            }
            return result;
        }

        public static void Func2(int[] arr, int m)
        {
            foreach (var a in arr)
            {
                Console.Write(string.Format("{0}, ", a));
            }
            Console.WriteLine();

            var dic = new Dictionary<int, List<int>>();
            for (var i = 0; i < arr.Length; i++)
            {
                var tmp = m - arr[i];
                if (!dic.ContainsKey(tmp))
                {
                    dic.Add(tmp, new List<int>());
                    dic[tmp].Add(i);
                }
                else
                    dic[tmp].Add(i);
            }

            for (var i = 0; i < arr.Length; i++)
            {
                if (dic.ContainsKey(arr[i]))
                    foreach (var elem in dic[arr[i]])
                    {
                        Console.WriteLine(string.Format("({0},{1})", i, elem));
                    }
            }
        }

        public static void Func3(int[] arr, int m)
        {
            var list = arr.ToList();
            list.Sort();
            foreach (var a in list)
            {
                Console.Write(string.Format("{0}, ", a));
            }
            Console.WriteLine();

            var start = 0;
            var end = list.Count - 1;

            while (end - start > 1)
            {
                if (list[start] + list[end] == m)
                {
                    int startNext = start;
                    int endNext = end;
                    while (startNext < list.Count && list[start] == list[startNext])
                    {
                        startNext++;
                    }
                    while (endNext >= 0 && list[end] == list[endNext])
                    {
                        endNext--;
                    }

                    for (int i = start; i < startNext; i++)
                    {
                        for (int j = end; j > endNext; j--)
                        {
                           Console.WriteLine("({0},{1})", i, j);
                        }
                    }

                    start = startNext;
                    end = endNext;
                }                
                else
                    if (list[start] + list[end] > m)
                        end--;
                    else
                        if (list[start] + list[end] < m)
                            start++;
            }
        }

        public int Func4(int[] arr, int m)
        {
            var result = 0;
            var list = arr.ToList();
            list.Sort();
            foreach (var a in list)
            {
                Console.Write(string.Format("{0}, ", a));
            }
            Console.WriteLine();

            var start = list.Count - 2;
            var end = list.Count - 1;

            while (end != 0)
            {
                if (list[end] - list[start] == m)
                {
                    result++;
                    if (start > 0)
                        start--;
                    if (end > 0)
                        end--;
                }

                if (list[end] - list[start] < m && start != 0)
                    start--;

                if (list[end] - list[start] > m && end != 0)
                    end--;
            }

            return result;
        }
    }
}