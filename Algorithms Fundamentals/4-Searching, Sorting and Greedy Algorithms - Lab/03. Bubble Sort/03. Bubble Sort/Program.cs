using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            BubbleSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void BubbleSort(int[] arr)
        {
            var isSorted = false;
            var sortedCount = 0;

            while (!isSorted)
            {
                isSorted = true;

                for (int right = 1; right < arr.Length - sortedCount; right++)
                {
                    var left = right - 1;

                    if (arr[left] > arr[right])
                    {
                        Swap(arr, left, right);
                        isSorted = false;
                    }
                }

                sortedCount += 1;
            }
        }

        private static void Swap(int[] numbers, int start, int end)
        {
            var temp = numbers[start];
            numbers[start] = numbers[end];
            numbers[end] = temp;
        }
    }
}
