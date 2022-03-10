using System;
using System.Linq;

namespace _01_Reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            ReverseArray(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ReverseArray(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;

            ReverseArray(arr, ++start, --end);
        }
    }
}
