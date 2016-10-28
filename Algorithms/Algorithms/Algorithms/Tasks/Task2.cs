using System;
using System.Collections.Generic;

//Fined all simple dividers of number

namespace Algorithms
{
    public static class Task2
    {
        public static IList<int> Func(int a)
        {
            var result = new List<int>();
            int num;
            for (var i = 1; i <= Math.Sqrt(a); i++)
            {
                num = a/i;
                if (a%i == 0)
                {
                    if (Check(i))
                    {
                        result.Add(i);
                    }
                    if (num != i && Check(num))
                        result.Add(num);
                }
            }
            result.Sort();
            return result;
        }

        private static bool Check(int num)
        {
            for (var i = 2; i <= Math.Sqrt(num); i++)
                if (num%i == 0)
                {
                    return false;
                }
            return true;
        }
    }
}