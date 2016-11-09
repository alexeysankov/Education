namespace Algorithms
{
    //Найти x^p по модулю M
    public class Task10
    {
        public static int Pow(int num, int pow, int mod)
        {
            if (pow == 1)
            {
                return num%mod;
            }

            if (pow % 2 == 0)
                return Pow((num*num)%mod, pow/2, mod)%mod;
            else
                return num * Pow((num*num)%mod, (pow-1)/2, mod)%mod;
        }
    }
}