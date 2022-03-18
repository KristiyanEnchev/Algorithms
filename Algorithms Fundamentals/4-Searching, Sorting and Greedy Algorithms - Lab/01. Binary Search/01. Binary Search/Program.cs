using System;
using System.Linq;

namespace _01._Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(arr, number));
        }

        private static int BinarySearch(int[] arr, int number)
        {
            var left = 0;
            var right = arr.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (arr[mid] == number)
                {
                    return mid;
                }

                if (number > arr[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}
