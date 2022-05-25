using System;

namespace _07._Minimum_Edit_Distance
{
    class Program
    {
        private static int[,] matrix;
        private static int replaceCost;
        private static int insertCost;
        private static int deleteCost;
        static void Main(string[] args)
        {
            replaceCost = int.Parse(Console.ReadLine());
            insertCost = int.Parse(Console.ReadLine());
            deleteCost = int.Parse(Console.ReadLine());

            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            matrix = new int[str1.Length + 1, str2.Length + 1];

            FillMatrix(str1, str2);
            Console.WriteLine($"Minimum edit distance: {matrix[str1.Length, str2.Length]}");
        }
        private static void FillMatrix(string str1, string str2) 
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + insertCost;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = matrix[row - 1, 0] + deleteCost;
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
                        var replace = matrix[row - 1, col - 1] + replaceCost;
                        var delete = matrix[row - 1, col] + deleteCost;
                        var insert = matrix[row, col - 1] + insertCost;

                        matrix[row, col] = Math.Min(Math.Min(replace, delete), insert); 
                    }
                }
            }
        }
    }
}
