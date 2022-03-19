using System;
using System.Linq;

namespace _02._Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split().Select(int.Parse)
                .ToArray();

            SelectionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                Swap(arr, i, min);
            }
        }

        private static void Swap(int[] arr, int start, int end)
        {
            var temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }
    }
}
