using System;

namespace _01._TBC
{
    class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static int totalAreas = 0;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            visited = new bool[rows, cols];

            ReadMatrix(rows, cols);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 't' && !IsWall(row, col) && !visited[row, col])
                    {
                        DFS(row, col);
                        totalAreas++;
                    }
                }
            }

            Console.WriteLine(totalAreas);
        }

        private static void DFS(int row, int col)
        {
            if (!IsValidCordinate(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            visited[row, col] = true;

            DFS(row - 1, col);
            DFS(row + 1, col);
            DFS(row, col + 1);
            DFS(row, col - 1);
            DFS(row - 1, col - 1);
            DFS(row + 1, col + 1);
            DFS(row - 1, col + 1);
            DFS(row + 1, col - 1);
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == 'd';
        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }

        public static bool IsValidCordinate(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        private static void ReadMatrix(int rows, int cols)
        {
            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var elements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];
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
