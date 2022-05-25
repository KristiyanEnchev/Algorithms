using System;

namespace _05._Word_Differences
{
    class Program
    {
        private static int[,] matrix;
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            FillMatrix(str1, str2);
            Console.WriteLine($"Deletions and Insertions: {matrix[str1.Length, str2.Length]}");
        }

        private static void FillMatrix(string str1, string str2)
        {
            matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = row;
            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = col;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else
                    {
                        matrix[row, col] = Math.Min(matrix[row, col -1] + 1, matrix[row - 1, col] + 1);
                    }
                }
            }
        }
    }
}