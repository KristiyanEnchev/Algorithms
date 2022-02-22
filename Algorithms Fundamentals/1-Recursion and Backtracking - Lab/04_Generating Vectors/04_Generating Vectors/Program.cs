using System;

namespace _04_Generating_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            GenerateVectors(arr, 0);
        }

        private static void GenerateVectors(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;

                GenerateVectors(arr, index + 1);
            }
        }
    }
}
