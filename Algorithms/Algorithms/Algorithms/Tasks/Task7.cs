using System;

namespace Algorithms
{
    //Дано поле размером mxn, поделенное на клетки размером 1x1 и заполненные случайными числами
    //Надо попасть из клетки 1x1 в nxm, двигаясь только вниз или вправо(т.е.координаты могут только увеличиваться). 
    //За один шаг можно двигаться только на 1 клетку.Надо найти такой путь, что бы сумма клеток была максимальной.

    public static class Task7
    {
        public static int Func(int n, int m)
        {
            var a = new int[n, m];

            var rand = new Random();
            int i;
            int j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    a[i, j] = rand.Next(-100, 100);
                    Console.Write(string.Format("{0} \t", a[i,j]));
                }
                Console.WriteLine();
            }

            i = 0;
            j = 0;
            var result = a[i, j];
            Console.WriteLine();
            while (i < n-1 && j < m-1)
            {
                Console.Write(string.Format("{0} \t", a[i, j]));
                if (a[i, j + 1] > a[i + 1, j])
                {
                    result += a[i, j + 1];
                    j++;
                }
                else
                {
                    result += a[i + 1, j];
                    i++;
                }

            }
            for (var k = i; k < n; k++)
            {
                for (var l = j; l < m; l++)
                {
                    result += a[k, l];
                    Console.Write(string.Format("{0} \t", a[k, l]));
                }
            }

            Console.WriteLine();

            return result;
        } 
    }
}