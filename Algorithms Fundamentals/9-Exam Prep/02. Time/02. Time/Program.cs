using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Time
{
    class Program
    {
        private static int[,] matrix;
        private static int[] first;
        private static int[] second;
        static void Main(string[] args)
        {
            first = Console.ReadLine().Split().Select(int.Parse).ToArray();
            second = Console.ReadLine().Split().Select(int.Parse).ToArray();

            matrix = new int[first.Length + 1, second.Length + 1];

            FillMatrix();
            //PrintMatrix();
            Console.WriteLine(string.Join(" ", GetSecuence()));
            Console.WriteLine(matrix[first.Length, second.Length]);
        }

        private static Stack<int> GetSecuence()
        {
            var sequence = new Stack<int>();
            var row = first.Length;
            var col = second.Length;

            while (row > 0 && col > 0)
            {
                if (first[row - 1] == second[col - 1] && matrix[row, col] == matrix[row - 1, col - 1] + 1)
                {
                    sequence.Push(first[row - 1]);

                    row -= 1;
                    col -= 1;
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

            return sequence;
        }

        private static void FillMatrix()
        {
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (first[row - 1] == second[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row, col - 1], matrix[row - 1, col]);
                    }
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
