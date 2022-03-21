using System;
using System.Linq;

namespace _04._Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            InsertionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void InsertionSort(int[] arr)
        {
            for (int right = 1; right < arr.Length; right++)
            {
                var left = right;

                while (left > 0 && arr[left - 1] > arr[left])
                {
                    Swap(arr, left, left - 1);
                    left -= 1;
                }
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