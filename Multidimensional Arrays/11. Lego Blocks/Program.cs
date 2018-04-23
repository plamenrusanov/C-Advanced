using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Lego_Blocks
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            var firstJagArray = new int[n][];
            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                firstJagArray[row] = new int[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    firstJagArray[row][col] = input[col];
                }
                count += input.Count();
            }

            var secondJagArray = new int[n][];
            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                secondJagArray[row] = new int[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    secondJagArray[row][col] = input[col];
                }
                count += input.Count();
            }

            firstJagArray = ReverseConcatJagArrays(firstJagArray, secondJagArray);
            bool isRectangular = IsRectangularMatrix(firstJagArray);

            if (isRectangular)
            {
                PrintMatrix(firstJagArray);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {count}");
            }
            
        }

        private static void PrintMatrix(int[][] firstJagArray)
        {
            for (int row = 0; row < firstJagArray.GetLength(0); row++)
            {
                Console.WriteLine($"[{string.Join(", ",firstJagArray[row])}]");
            }
        }

        private static bool IsRectangularMatrix(int[][] firstJagArray)
        {
            bool isRect = true;
            int count = firstJagArray[0].Length;
            for (int row = 1; row < firstJagArray.GetLength(0); row++)
            {
                if (firstJagArray[row].Length != count)
                {
                    isRect = false;
                }
            }
            return isRect;
        }

        private static int[][] ReverseConcatJagArrays(int[][] firstJagArray, int[][] secondJagArray)
        {
           
            for (int row = 0; row < secondJagArray.GetLength(0); row++)
            {
                Stack<int> reverse = new Stack<int>(secondJagArray[row]);
                for (int col = 0; col < secondJagArray[row].Length; col++)
                {
                    secondJagArray[row][col] = reverse.Pop();
                }
                firstJagArray[row] =  firstJagArray[row].Concat(secondJagArray[row]).ToArray();              
            }
            return firstJagArray;
        }
    }
}
