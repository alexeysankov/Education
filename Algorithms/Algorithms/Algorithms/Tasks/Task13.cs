namespace Algorithms
{
    //Count the number of sequences of zeroes and ones of length n, which do not contain two subsequent ones
    //найти количество последовательностей из 0 и 1 длины n,  в которых 1 не встречается два раза подряд
    public class Task13
    {
        public static int Func(int n)
        {
            var a = 1;
            var b = 1;

            for (var i = 1; i < n; i++)
            {
                var prevA = a;
                a = a + b;
                b = prevA;
            }
            return a + b;
        }        
    }
}