namespace Algorithms
{
    //Fined number position in ordered array
    public static class Task1
    {
        public static int recFunc(int[] arr, int num)
        {
            var start = 0;
            var end = arr.Length - 1;
            var result = -1;
            int mid;

            while ((end - start > 1) && result == -1)
            {
                mid = (end - start) / 2;
                if (num == arr[start])
                    result = start;
                if (num == arr[end])
                    result = end;
                if (num < arr[start + mid] && num > arr[start])
                    end = end - mid;
                else
                    start = start + mid;

            }
            return result;
        }
    }
}