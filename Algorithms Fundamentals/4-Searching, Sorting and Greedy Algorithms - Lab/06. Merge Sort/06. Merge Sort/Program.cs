using System;
using System.Linq;

namespace _06._Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();

            var sorted = MergeSort(arr);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            var left = arr.Take(arr.Length / 2).ToArray();
            var right = arr.Skip(arr.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergedIndex = 0;
            var leftIndex = 0;
            var rightindex = 0;

            while (leftIndex < left.Length && rightindex < right.Length)
            {
                if (left[leftIndex] < right[rightindex])
                {
                    merged[mergedIndex++] = left[leftIndex++];
                }
                else
                {
                    merged[mergedIndex++] = right[rightindex++];
                }
            }

            for (int i = leftIndex; i < left.Length; i++)
            {
                merged[mergedIndex++] = left[i];
            }

            for (int i = rightindex; i < right.Length; i++)
            {
                merged[mergedIndex++] = right[i];
            }

            return merged;
        }
    }
}
