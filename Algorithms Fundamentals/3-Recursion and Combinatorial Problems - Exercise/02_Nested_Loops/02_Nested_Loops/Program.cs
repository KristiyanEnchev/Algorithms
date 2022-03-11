using System;

namespace _02_Nested_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var arr = new int[number];

            PrintCombinations(arr, 0);
        }

        private static void PrintCombinations(int[] arr, int start)
        {
            if (start == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[start] = i;
                PrintCombinations(arr, start + 1);
            }
        }
    }
}
