using System;
using System.Linq;

namespace _05.Generating_Combinations
{
    class Program
    {
        static void Main()
        {
            var set = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var k = int.Parse(Console.ReadLine());

            var vector = new int[k];

            Gen(set, vector, 0, 0);
        }

        private static void Gen(int[] set, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (var i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];

                    Gen(set, vector, index + 1, i + 1);
                }
            }
        }
    }
}