using System;
using System.Linq;

namespace _7.Squares_in_Matrix
{
    class Program
    {
        static void Main()
        {
            int[] sizeMatrix = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int equalSquares = 0;
            char[][] matrix = new char[sizeMatrix[0]][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = new char[sizeMatrix[1]];
                char[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }

            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    if (matrix[row][col].Equals(matrix[row][col + 1]) && 
                        matrix[row][col].Equals(matrix[row + 1][col]) &&
                        matrix[row][col].Equals(matrix[row + 1][col + 1]))
                    {
                        equalSquares++;
                    }
                }
            }

            Console.WriteLine(equalSquares);
        }
    }
}
