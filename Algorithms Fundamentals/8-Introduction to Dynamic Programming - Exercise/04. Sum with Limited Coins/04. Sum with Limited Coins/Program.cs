using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Sum_with_Limited_Coins
{
    class Program
    {
        private static int[] coins;
        private static int target;
        static void Main(string[] args)
        {
            coins = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            target = int.Parse(Console.ReadLine());

            Console.WriteLine(Combinations());

        }

        private static int Combinations()
        {
            var count = 0;
            var sums = new HashSet<int> { 0 };

            foreach (var coin in coins)
            {
                var newSums = new HashSet<int>();
                foreach (var sum in sums)
                {
                    var newSum = sum + coin;

                    if (newSum == target)
                    {
                        count += 1;
                    }

                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return count;
        }
    }
}