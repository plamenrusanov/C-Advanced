using System;
using System.Linq;

namespace _6.Diagonal_Difference
{
    class Program
    {
        static void Main()
        {
            int sizeSquareMatrix = int.Parse(Console.ReadLine());

            int[][] squareMatrix = new int[sizeSquareMatrix][];

            for (int i = 0; i < sizeSquareMatrix; i++)
            {
                int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                squareMatrix[i] = new int[input.Length];
                for (int num = 0; num < input.Length; num++)
                {
                    squareMatrix[i][num] = input[num]; 
                }
            }

            int firstSum = 0;
            int secondSum = 0;
            for (int i = 0; i < squareMatrix.GetLength(0); i++)
            {
                firstSum += squareMatrix[i][i];
                secondSum += squareMatrix[i][squareMatrix.GetLength(0) - 1 - i];
            }

            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}
