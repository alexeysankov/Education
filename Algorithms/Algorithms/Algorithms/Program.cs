using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmp = new Stack();
            tmp.Push(11);
            tmp.Push(22);
            tmp.Push(33);
            Console.WriteLine(tmp.Pop());
            Console.WriteLine(tmp.Pop());
            Console.WriteLine(tmp.Pop());
            Console.ReadKey();
        }
    }
}
