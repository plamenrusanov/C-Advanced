using System;
using System.Linq;

namespace _5.Matrix_of_Palindromes
{
    class Program
    {
        static void Main()
        {
            int[] sizeMatrix = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string[,] matrix = new string[sizeMatrix[0], sizeMatrix[1]];

            for (char row = 'a'; row < 97 + matrix.GetLength(0); row++)
            {
                for (char col = row; col <  row + matrix.GetLength(1) ; col++)
                {
                    Console.Write($"{row}{col}{row} ");
                }
                Console.WriteLine();
            }
        }
    }
}
