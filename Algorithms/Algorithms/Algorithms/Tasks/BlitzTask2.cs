using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Algorithms
{
    //https://www.hackerrank.com/challenges/two-characters
    class BlitzTask2
    {
        public static void Func()
        {
            var len = Convert.ToInt32(Console.ReadLine());
            var s = Console.ReadLine();

            var strArr = s.ToCharArray();
            var uniqueChars = strArr.Distinct().ToArray();
            var result = 0;

            for (var i = 0; i < uniqueChars.Length - 1; i++)
            {
                for (var j = i + 1; j < uniqueChars.Length; j++)
                {
                    var tmpArr = strArr.Where(x => (x == uniqueChars[i] || x == uniqueChars[j])).ToArray();
                    if (Fnc(tmpArr) && result < tmpArr.Length)
                        result = tmpArr.Length;
                }
            }

            Console.WriteLine(result);
        }

        public static bool Fnc(char[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] == arr[i]) return false;
            }
            return true;
        }
    }
}
