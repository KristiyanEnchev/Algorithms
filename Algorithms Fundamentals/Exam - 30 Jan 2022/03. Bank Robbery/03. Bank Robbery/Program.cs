using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Bank_Robbery
{
    class Program
    {
        private static int[] boxes;
        static void Main(string[] args)
        {
            boxes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var allSums = FindAllSums(boxes);
            var totalSum = boxes.Sum();
            var Joshsum = totalSum / 2;

            var JoshBoxes = new List<int>();
            var PrakashBoxes = new List<int>();

            while (JoshBoxes.Count == 0 && PrakashBoxes.Count == 0)
            {
                if (allSums.ContainsKey(Joshsum))
                {
                    JoshBoxes = FindSubSet(allSums, Joshsum);
                    PrakashBoxes = boxes.Except(JoshBoxes).ToList();
                }

                Joshsum -= 1;
            }
            Console.WriteLine($"{string.Join(" ", JoshBoxes.OrderBy(x => x))}");
            Console.WriteLine($"{string.Join(" ", PrakashBoxes.OrderBy(x => x))}");
        }
        private static Dictionary<int, int> FindAllSums(int[] elements)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var element in elements)
            {
                var currentSum = sums.Keys.ToArray();

                foreach (var sum in currentSum)
                {
                    var newSum = sum + element;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, element);
                }
            }

            return sums;
        }

        private static List<int> FindSubSet(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while (target != 0)
            {
                var element = sums[target];
                subset.Add(element);

                target -= element;
            }

            return subset;
        }
    }
}
