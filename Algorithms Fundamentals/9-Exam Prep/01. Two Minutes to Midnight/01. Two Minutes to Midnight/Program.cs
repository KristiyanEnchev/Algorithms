using System;
using System.Collections.Generic;

namespace _01._Two_Minutes_to_Midnight
{
    class Program
    {
        private static Dictionary<string, long> cach;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            cach = new Dictionary<string, long>();

            Console.WriteLine(GetFibonacci(n, k));
        }

        private static long GetFibonacci(int n, int k)
        {
            if (k == 0 || k == n || n <= 1 )
            {
                return 1;
            }

            var key = $"{n}-{k}";

            if (cach.ContainsKey(key))
            {
                return cach[key];
            }

            var result = GetFibonacci(n - 1, k - 1) + GetFibonacci(n - 1, k);
            cach[key] = result;
            return result;
        }
    }
}
