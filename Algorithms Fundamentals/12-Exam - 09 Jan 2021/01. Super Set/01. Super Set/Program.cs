using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Super_Set
{
    class Program
    {
        private static int[] arr;
        private static List<string> result;
        static void Main(string[] args)
        {
            arr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            result = new List<string>();

            GenerateSets();

            Console.WriteLine(string.Join(Environment.NewLine, result));

        }
       
        private static void Combinations(int index, int startIndex, int[] combinations)
        {
            if (index >= combinations.Length)
            {
                result.Add(string.Join(" ", combinations));
                return;
            }

            for (int i = startIndex; i < arr.Length; i++)
            {
                combinations[index] = arr[i];
                Combinations(index + 1, i + 1, combinations);
            }
        }

        private static void GenerateSets()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int[] combinations = new int[i + 1];

                Combinations(0, 0, combinations);
            }
        }
    }
}
