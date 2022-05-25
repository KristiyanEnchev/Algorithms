using System;

namespace _03._Longest_Common_Subsequence
{
    class Program
    {
        private static int[,] matrix;
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            matrix = ReadMatrix(str1, str2);

            Console.WriteLine(matrix[str1.Length, str2.Length]);
        }

        private static int[,] ReadMatrix(string one, string two)
        {
            matrix = new int[one.Length + 1, two.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (one[row - 1] == two[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row, col - 1], matrix[row - 1, col]);
                    }
                }
            }

            return matrix;
        }
    }
}
