using System;
using System.Linq;

namespace _01_Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(SumRecursivly(numbers, 0));
        }

        private static int SumRecursivly(int[] numbers, int index)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + SumRecursivly(numbers, index + 1);
        }
    }
}
