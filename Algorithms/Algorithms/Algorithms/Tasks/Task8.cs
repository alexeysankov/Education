using System;
using System.Collections;
using System.Linq;

namespace Algorithms
{
    //Минимизировать разность сумм между двумя кучками монет
    public static class Task8
    {
        public static int Func(int[] arr)
        {
            Array.Sort(arr);
            Array.Reverse(arr);
            var sum1 = arr[0];
            var sum2 = arr[1];
            for (var i = 2; i < arr.Length; i++)
            {
                if (sum1 < sum2)
                    sum1 += arr[i];
                else
                    sum2 += arr[i];
            }
            return Math.Abs(sum1-sum2);
        }

        public static int Func2(int[] arr)
        {
            var razn = arr.Sum();
            var tmp = (Math.Pow(2, arr.Length)-2)/2;
            for (var i = 1; i < tmp; i++)
            {
                var b = new BitArray(new[] { i });
                var sum1 = 0;
                var sum2 = 0;
                for (var j = 0; j < arr.Length; j++)
                {
                    if (b[j])
                        sum1 += arr[j];
                    else
                        sum2 += arr[j];
                }
                if (Math.Abs(sum1 - sum2) < razn)
                    razn = Math.Abs(sum1 - sum2);
            }
            return razn;
        }
    }
}