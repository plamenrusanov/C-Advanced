using System;
using System.Collections.Generic;

namespace _16._String_Matrix_Rotation
{
    class Program
    {
        static void Main()
        {
            string[] rotation = Console.ReadLine().Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            int rotate = int.Parse(rotation[1]) % 360;

            List<char[]> matrix = new List<char[]>();
            int maxLength = 0;
            string input = Console.ReadLine();
            int row = 0;
            while (input != "END")
            {
                if (maxLength < input.Length )
                {
                    maxLength = input.Length;
                }
                matrix.Add(new char[input.Length]);
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }
                input = Console.ReadLine();
                row++;
            }

            switch (rotate)
            {
                case 0:
                    RotateLeft(matrix);
                    break;
                case 90:
                    RotateUp(matrix, maxLength);
                    break;
                case 180:
                    RotateRight(matrix, maxLength);
                    break;
                case 270:
                    RotateDown(matrix, maxLength);
                    break;
            }

        }

        private static void RotateDown(List<char[]> matrix, int maxLength)
        {
            for (int row = maxLength - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.Count; col++)
                {
                    if (matrix[col].Length > row)
                    {
                        Console.Write(matrix[col][row]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void RotateRight(List<char[]> matrix, int maxLength)
        {
            for (int row = matrix.Count - 1; row >= 0; row--)
            {
                for (int col = maxLength -1; col >= 0; col--)
                {
                    if (matrix[row].Length > col)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void RotateUp(List<char[]> matrix, int maxLength)
        { 
            for (int row = 0; row < maxLength; row++)
            {
                for (int col = matrix.Count -1; col >= 0; col--)
                {
                    if (matrix[col].Length > row)
                    {
                        Console.Write(matrix[col][row]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();             
            }
        }

        private static void RotateLeft(List<char[]> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write( matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
