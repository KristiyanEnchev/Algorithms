using System;
using System.Collections.Generic;

namespace _02._Areas_in_Matrix
{
    class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine()); 

            matrix = ReadMatrix(rows, cols);
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();
            var areaCount = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }

                    var letter = matrix[row, col];
                    DFS(row, col, letter);

                    areaCount += 1;

                    if (areas.ContainsKey(letter))
                    {
                        areas[letter] += 1;
                    }
                    else
                    {
                        areas[letter] = 1;
                    }
                }
            }

            Console.WriteLine($"Areas: {areaCount}");

            foreach (var kvp in areas)
            {
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value} ");
            }
        }

        private static void DFS(int row, int col, char letter)
        {
            if (!IsValidCordinate(row, col) || visited[row, col] || IsDifferentLetter(row, col, letter))
            {
                return;
            }

            visited[row, col] = true;

            DFS(row - 1, col, letter);
            DFS(row + 1, col, letter);
            DFS(row, col - 1, letter);
            DFS(row, col + 1, letter);
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

        public static bool IsValidCordinate(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        public static bool IsDifferentLetter(int row, int col, char letter) 
        {
            return matrix[row, col] != letter;
        }
    }
}
