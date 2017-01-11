using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    //https://www.hackerrank.com/challenges/bear-and-steady-gene
    public class BlitzTask3
    {
        public static void Func()
        {
            var count = Convert.ToInt32(Console.ReadLine());
            var str = Console.ReadLine() ?? "";
            var result = 0;
            var col = count/4;
            var arrStr = str.ToCharArray();
            var dict = new Dictionary<char, int>();
            for (var i = 0; i < count; i++)
            {
                if (dict.ContainsKey(arrStr[i]))
                    dict[arrStr[i]]++;
                else
                    dict.Add(arrStr[i], 1);
            }
            


            Console.WriteLine(result);
        }
    }
}