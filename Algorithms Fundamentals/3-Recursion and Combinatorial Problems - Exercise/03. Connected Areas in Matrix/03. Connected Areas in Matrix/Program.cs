using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Connected_Areas_in_Matrix
{
    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }

    class Program
    {
        private const char visited = 'v'; 

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = ReadMatrix(rows, cols);

            var areas = new List<Area>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var area = new Area { Row = row, Col = col};

                    ExproreArea(row, col, area, matrix);

                    if (area.Size != 0)
                    {
                        areas.Add(area);
                    }
                }
            }

            var sorted = areas.OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {sorted.Count}");

            for (int i = 0; i < sorted.Count; i++)
            {
                var area = sorted[i];
                Console.WriteLine($"Area #{i + 1} at ({area.Row}, {area.Col}), size: {area.Size}");
            }

        }

        private static void ExproreArea(int row, int col, Area area, char[,] matrix)
        {
            if (!IsValidCordinate(matrix, row, col) || IsWall(row, col, matrix) || IsVisited(row, col , matrix))
            {
                return;
            }

            area.Size += 1;
            matrix[row, col] = visited;

            ExproreArea(row - 1, col, area, matrix);
            ExproreArea(row + 1, col, area, matrix);
            ExproreArea(row, col - 1, area, matrix);
            ExproreArea(row, col + 1, area, matrix);
        }

        private static bool IsWall(int row, int col, char[,] matrix)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsVisited(int row, int col, char[,] matrix)
        {
            return matrix[row, col] == visited;
        }

        public static bool IsValidCordinate(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] array = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            return matrix;
        }
    }
}
