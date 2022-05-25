    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _02._Dividing_Presents
    {
        class Program
        {
            static void Main(string[] args)
            {
                var secuence = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var allSums = FindAllSums(secuence);

                var totalSum = secuence.Sum();
                var alanSum = totalSum / 2;

                while (true)
                {
                    if (allSums.ContainsKey(alanSum))
                    {
                        var alanPresents = FindSubSet(allSums, alanSum);

                        var bobSum = totalSum - alanSum;
                        Console.WriteLine($"Difference: {bobSum - alanSum}");
                        Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                        Console.WriteLine($"Alan takes: {string.Join(" ",alanPresents)}");
                        Console.WriteLine($"Bob takes the rest.");
                        break;
                    }

                    alanSum -= 1;
                }
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

            private static Dictionary<int, int> FindAllSums(int[] elements)
            {
                var sums = new Dictionary<int, int> { { 0, 0} };

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
        }
    }
