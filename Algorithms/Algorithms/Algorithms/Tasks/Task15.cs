using System;
using System.Linq;

namespace Algorithms
{
    //Reverse the words in the array without additional memory
    public class Task15
    {
        public static void Func(string str)
        {
            var revStr = str.ToArray();
            Reverce(revStr, 0, str.Length-1);

            var wordStart = 0;
            for (var i = 0; i < revStr.Length; i++)
            {
                if (revStr[i] == ' ')
                {
                    Reverce(revStr, wordStart, i - 1);
                    wordStart = i+1;
                }
                if(i==revStr.Length-1)
                    Reverce(revStr, wordStart, i);
            }

            Console.WriteLine(new string(revStr));
        }

        private static void Reverce(char[] ch, int s, int e)
        {
            for (var i = s; i <= (s+e)/2; i++)
            {
                var tmp = ch[i];
                ch[i] = ch[s + e - i];
                ch[s + e - i] = tmp;
            }
        }
    }
}