using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Move_Down_Right
{
    class Program
    {
        private static int[,] matrix;
        private static int[,] maxMatrix;
        private static Stack<string> path;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(rows, cols);
            maxMatrix = CalculateMaxMatrix(rows, cols);

            var row = rows - 1;
            var col = cols - 1;

            path = FindPath(row, col);

            Console.WriteLine(string.Join(" ", path));
        }

        private static int[,] CalculateMaxMatrix(int rows, int cols)
        {
            var dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int col = 1; col < cols; col++)
            {
                dp[0, col] = dp[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                dp[row, 0] = dp[row - 1, 0] + matrix[row, 0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    var upper = dp[row - 1, col];
                    var left = dp[row, col - 1];

                    dp[row, col] = Math.Max(upper, left) + matrix[row, col];
                }
            }

            return dp;
        }

        private static Stack<string> FindPath(int row, int col)
        {
            path = new Stack<string>();

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                var upper = maxMatrix[row - 1, col];
                var left = maxMatrix[row, col - 1];

                if (upper > left)
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }
            }

            while (row > 0)
            {
                path.Push($"[{row}, {col}]");
                row -= 1;
            }

            while (col > 0)
            {
                path.Push($"[{row}, {col}]");
                col -= 1;
            }

            path.Push($"[{row}, {col}]");
            return path;
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            return matrix;
        }
    }
}
