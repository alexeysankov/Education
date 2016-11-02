﻿namespace Algorithms
{
    //Дано поле размером mxn, поделенное на клетки размером 1x1.
    //Надо попасть из клетки 1x1 в nxm, двигаясь только вниз или вправо(т.е.координаты могут только увеличиваться). 
    //За один шаг можно двигаться только на 1 клетку.Надо найти количество способов добраться из одного угла в другой

    public static class Task6
    {
        public static long Func(int n, int m)
        {
            var a = new long[n, m];
            for (var i = n - 1; i >= 0; i--)
                for (var j = m - 1; j >= 0; j--)
                {
                    a[i, j] = (i == n - 1) || (j == m - 1) ? 1 : a[i + 1, j] + a[i, j + 1];
                }

            return a[0, 0];
        }
    }
}