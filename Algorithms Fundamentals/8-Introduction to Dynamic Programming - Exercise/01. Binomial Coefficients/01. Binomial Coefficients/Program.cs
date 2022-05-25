using System;
using System.Collections.Generic;

namespace _01._Binomial_Coefficients
{
    class Program
    {
        private static Dictionary<string, long> cach;

        static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            cach = new Dictionary<string, long>();

            Console.WriteLine(FindBinomial(row, col));
        }

        private static long FindBinomial(int row, int col)
        {
            if (col == 0 || col == row)
            {
                return 1;
            }

            var key = $"{row}-{col}";

            if (cach.ContainsKey(key))
            {
                return cach[key];
            }

            var ressult = FindBinomial(row - 1, col - 1) + FindBinomial(row - 1, col);
            cach[key] = ressult;

            return ressult;
        }
    }
}
