using System;
using System.Collections.Generic;

namespace _01._Fibonacci
{
    class Program
    {
        private static Dictionary<int, long> cach = new Dictionary<int, long>();
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFibonacci(n));
        }

        private static long CalculateFibonacci(int n) 
        {
            if (cach.ContainsKey(n))
            {
                return cach[n];
            }

            if (n < 2)
            {
                return n;
            }

            var result = CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
            cach[n] = result;

            return result;
        }
    }
}
