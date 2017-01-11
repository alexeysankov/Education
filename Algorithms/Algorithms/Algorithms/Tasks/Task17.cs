using System;

namespace Algorithms
{
    //Fint specific value in matrix which has elements which are greater that their upper and left neighbours
    //есть матрица, в которой каждое значение больше остальных значений слева или сверху относительно него. надо найти в такой матрице определенное значение
    public class Task17
    {
        public static void Func()
        {            
            var size = 10;
            var arr = new int[size, size];
            var rand = new Random();
            arr[0, 0] = rand.Next(10);
            for (var i = 1; i < size; i++)
            {
                arr[0, i] = rand.Next(arr[0, i - 1], arr[0, i - 1] + 10);
                arr[i, 0] = rand.Next(arr[i - 1, 0], arr[i - 1, 0] + 10);
            }
            for (var i = 1; i < size; i++)
            {
                for (var j = 1; j < size; j++)
                {
                    var maxVal = arr[i - 1, j] > arr[i, j - 1] ? arr[i - 1, j] : arr[i, j - 1];
                    arr[i, j] = rand.Next(maxVal, maxVal + 10);
                }
            }
            Out(arr, 0, 0, size-1, size-1);


            var num = arr[2, 2];


            /////////
            var xe = size - 1;
            var ye = size - 1;
            while (xe > 0 && arr[xe, 0] > num)
            {
                xe--;
            }
            while (ye > 0 && arr[0, ye] > num)
            {
                ye--;
            }
            var ys = 0;
            var xs = 0;
            while (ys < size && arr[xe, ys] < num)
            {
                ys++;
            }
            while (xs < size && arr[xs, ye] < num)
            {
                xs++;
            }
            ////////
            
            var xe2 = recFunc(arr, 0, size - 1, 0, 0, num);
            var ye2 = recFunc(arr, 0, 0, 0, size - 1, num);

            var xs2 = recFunc2(arr, 0, xe2, ye2, ye2, num);
            var ys2 = recFunc2(arr, xe2, xe2, 0, ye2, num);

            Console.WriteLine($"{xs}, {xe}, {ys}, {ye}");
            Console.WriteLine($"{xs2}, {xe2}, {ys2}, {ye2}");


            ////////

            Out(arr, xs, ys, xe, ye);
            Console.WriteLine("({0})", num);
            for (var i = xs; i <= xe; i++)
            {
                for (var j = ys; j <= ye; j++)
                {
                    if(arr[i,j]==num)
                        Console.WriteLine("({0}, {1}) {2}", j, i, arr[i, j]);
                }
            }
        }

        private static void Out(int[,] arr, int xs, int ys, int xe, int ye)
        {
            for (var i = xs; i <= xe; i++)
            {
                for (var j = ys; j <= ye; j++)
                {
                    Console.Write(string.Format("{0} \t", arr[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static int recFunc(int[,] arr, int xs, int xe, int ys, int ye, int num)
        {
            var result = -1;

            if (xs == xe)
            {
                var start = ys;
                var end = ye;
                int mid;

                while ((end - start > 1) && result == -1)
                {
                    mid = (end - start)/2;
                    if (num == arr[xs, start])
                        result = start;
                    if (num == arr[xs, end])
                        result = end;
                    if (num < arr[xs, start + mid] && num > arr[xs, start])
                        end = end - mid;
                    else
                        start = start + mid;

                }

                if (result == -1)
                    result = start;
            }
            else
            {
                var start = xs;
                var end = xe;
                int mid;

                while ((end - start > 1) && result == -1)
                {
                    mid = (end - start) / 2;
                    if (num == arr[start, ys])
                        result = start;
                    if (num == arr[end, ys])
                        result = end;
                    if (num < arr[start + mid, ys] && num > arr[start, ys])
                        end = end - mid;
                    else
                        start = start + mid;

                }
                if (result == -1)
                    result = start;
            }
            return result;
        }

        public static int recFunc2(int[,] arr, int xs, int xe, int ys, int ye, int num)
        {
            var result = -1;

            if (xs == xe)
            {
                var start = ys;
                var end = ye;
                int mid;

                while ((end - start > 1) && result == -1)
                {
                    mid = (end - start) / 2;
                    if (num == arr[xs, start])
                        result = start;
                    if (num == arr[xs, end])
                        result = end;
                    if (num < arr[xs, start + mid] && num > arr[xs, start])
                        end = end - mid;
                    else
                        start = start + mid;

                }

                if (result == -1)
                    result = end;
            }
            else
            {
                var start = xs;
                var end = xe;
                int mid;

                while ((end - start > 1) && result == -1)
                {
                    mid = (end - start) / 2;
                    if (num == arr[start, ys])
                        result = start;
                    if (num == arr[end, ys])
                        result = end;
                    if (num < arr[start + mid, ys] && num > arr[start, ys])
                        end = end - mid;
                    else
                        start = start + mid;

                }
                if (result == -1)
                    result = end;
            }
            return result;
        }
    }
}