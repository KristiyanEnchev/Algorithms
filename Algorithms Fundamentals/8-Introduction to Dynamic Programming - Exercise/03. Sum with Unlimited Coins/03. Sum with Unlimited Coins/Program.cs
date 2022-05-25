using System;
using System.Linq;

namespace _03._Sum_with_Unlimited_Coins
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
            var sums = new int[target + 1];
            sums[0] = 1;

            foreach (var coin in coins)
            {
                for (int sum = coin; sum <= target; sum++)
                {
                    sums[sum] += sums[sum - coin];
                }
            }
            return sums[target];
        }
    }
}
