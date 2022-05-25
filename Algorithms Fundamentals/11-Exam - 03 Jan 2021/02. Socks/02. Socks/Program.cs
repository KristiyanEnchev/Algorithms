using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Socks
{
    class Program
    {
        private static int[,] matrix;
        private static Stack<int> subsequence;
        static void Main(string[] args)
        {
            var sok1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sok2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            subsequence = new Stack<int>();
            matrix = ReadMatrix(sok1, sok2);
            Subsequence(sok1, sok2);
            //PrintMatrix();
            Console.WriteLine(matrix[sok1.Length, sok2.Length]);
        }

        private static int[,] ReadMatrix(int[] one, int[] two)
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
        private static void Subsequence(int[] sok1, int[] sok2)
        {
            var row = sok1.Length;
            var col = sok2.Length;

            while (row > 0 && col > 0)
            {
                if (sok1[row - 1] == sok2[col - 1] &&
                    matrix[row - 1, col - 1] == matrix[row, col] - 1)
                {
                    row -= 1;
                    col -= 1;

                    subsequence.Push(sok1[row]);
                }
                else if (matrix[row - 1, col] > matrix[row, col - 1])
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
