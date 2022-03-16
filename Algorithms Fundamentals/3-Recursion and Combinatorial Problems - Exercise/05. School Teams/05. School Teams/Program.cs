using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._School_Teams
{
    class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var girlsComb = new string[3];
            var girlsCombs = new List<string[]>();

            GenCombinations(0, 0, girls, girlsComb, girlsCombs);

            var boys = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var boysComb = new string[2];
            var boysCombs = new List<string[]>();

            GenCombinations(0, 0, boys, boysComb, boysCombs);

            PrintFinalCombinations(girlsCombs, boysCombs);
        }

        private static void PrintFinalCombinations(List<string[]> girlsCombs, List<string[]> boysCombs)
        {
            foreach (var girlComb in girlsCombs)
            {
                foreach (var boyComb in boysCombs)
                {
                    Console.WriteLine($"{string.Join(", ", girlComb)}, {string.Join(", ", boyComb)}");
                }
            }
        }

        private static void GenCombinations(int index, int start, string[] elements, string[] combinations, List<string[]>girlsCombs)
        {
            if (index >= combinations.Length)
            {
                girlsCombs.Add(combinations.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                GenCombinations(index + 1, i + 1, elements, combinations, girlsCombs);
            }
        }
    }
}
