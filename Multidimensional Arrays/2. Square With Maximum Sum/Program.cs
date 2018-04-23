using System;
using System.Linq;

namespace _2.Square_With_Maximum_Sum
{
    class Program
    {
        static void Main()
        {
            int[] sizeMatrix = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = sizeMatrix[0];
            int columns = sizeMatrix[1];

            int[,] matrix = new int[rows, columns];
          
            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = input[col];                   
                }
            }

            int sum = int.MinValue;
            int r = 0;
            int c = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1]
                                   + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        r = row;
                        c = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[r, c]} {matrix[r, c + 1]}");
            Console.WriteLine($"{matrix[r+1, c]} {matrix[r+1, c+1]}");
            Console.WriteLine(sum);
        }
    }
}
