using System;
using System.Linq;

namespace _05._Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Quicksort(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Quicksort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (arr[left] > arr[pivot] && arr[right] < arr[pivot])
                {
                    Swap(arr, left, right);
                }

                if (arr[left] <= arr[pivot])
                {
                    left += 1;
                }

                if (arr[right] >= arr[pivot])
                {
                    right -= 1;
                }
            }

            Swap(arr, pivot, right);

            var isLeftSubArraysSmaller =
            right - 1 - start < end - (right + 1);

            if (isLeftSubArraysSmaller)
            {
                Quicksort(arr, start, right - 1);
                Quicksort(arr, right + 1, end);
            }
            else
            {
                Quicksort(arr, right + 1, end);
                Quicksort(arr, start, right - 1);
            }

            //Quicksort(arr, start, right - 1);
            //Quicksort(arr, right + 1, end);
        }

        private static void Swap(int[] arr, int start, int end)
        {
            var temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }
    }
}
