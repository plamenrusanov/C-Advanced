using System;
using System.Linq;

namespace _4.Maximal_Sum
{
    class Program
    {
        static void Main()
        {
            int[] sizeMatrix = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[][] matrix = new int[sizeMatrix[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int maxSum = int.MinValue;
            int r = 0;
            int c = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                       + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2]
                       + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        r = row;
                        c = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[r][c]} {matrix[r][c + 1]} {matrix[r][c + 2]}");
            Console.WriteLine($"{matrix[r + 1][c]} {matrix[r + 1][c + 1]} {matrix[r + 1][c + 2]}");
            Console.WriteLine($"{matrix[r + 2][c]} {matrix[r + 2][c + 1]} {matrix[r + 2][c + 2]}");

        }
    }
}
