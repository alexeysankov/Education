using System;
using System.Collections.Generic;

namespace Algorithms
{
    //неправильная
    public class BlitzTask1
    {
        public static void Func()
        {
            var count = Convert.ToInt32(Console.ReadLine() ?? "0");
            var strs = new List<string>();
            for (var i = 0; i < count; i++)
            {
                var tmp = Console.ReadLine();
                strs.Add(tmp);
            }
            foreach (var str in strs)
            {
                Console.WriteLine(Calc(str));
            }
        }

        public static int Calc(string str)
        {
            var list = new List<string>();
            var result = 0;
            var tmpStr = str.ToCharArray();
            for (var i = 0; i < tmpStr.Length-1; i++)
            {
                for (var j = i+1; j < tmpStr.Length; j++)
                    if (tmpStr[i] == tmpStr[j])
                        result++;
                    else
                        if (list.Contains($"{tmpStr[j]}{tmpStr[i]}"))
                            result++;
                        else
                            list.Add($"{tmpStr[i]}{tmpStr[j]}");   
            }

            return result;
        }
    }
}