using System;

namespace _02_Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFacturiel(n));
        }

        private static int CalculateFacturiel(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * CalculateFacturiel(n - 1);
        }
    }
}
