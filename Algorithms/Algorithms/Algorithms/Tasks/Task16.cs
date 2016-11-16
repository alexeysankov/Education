using System;
using System.Collections.Generic;

namespace Algorithms
{
    //найти самую днинную подпоследовательность последовательности скобок
    public class Task16
    {
        public static void Func(string brStr)
        {
            var stack = new Stack<string>();
            var result = 0;
            for (var i = 0; i < brStr.Length; i++)
            {
                if (brStr[i].ToString() == "(")
                {
                    stack.Push(brStr[i].ToString());
                }
                if (brStr[i].ToString() == ")" && stack.Count > 0)
                {
                    stack.Pop();
                    result++;
                }
            }
            Console.WriteLine(result*2);
        }
    }
}