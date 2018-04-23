using System;
using System.Linq;
using System.Collections.Generic;
namespace _10.Target_Practice
{
    class Program
    {
        static char[][] stairs;
        static int[] dimensions;
        static void Main()
        {
            dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int[] shotParam = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            FillStairs(snake);
            Shooting(shotParam);
            FallDown();
            PrintResult();
        }

        private static void PrintResult()
        {
            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs[row].Length; col++)
                {
                    Console.Write(stairs[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void FallDown()
        {
            for (int row = stairs.GetLength(0) -1; row >= 0; row--)
            {
                for (int col = 0; col < stairs[row].Length; col++)
                {
                    if (stairs[row][col] == ' ')
                    {
                        for (int r = row; r >= 0 ; r--)
                        {
                            if (stairs[r][col] != ' ')
                            {
                                stairs[row][col] = stairs[r][col];
                                stairs[r][col] = ' ';
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void Shooting(int[] shotParam)
        {
            int r = shotParam[0];
            int c = shotParam[1];
            int radius = shotParam[2]; 
            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                if (row >= r - radius || row <= r + radius)
                {
                    for (int col = 0; col < stairs[row].Length; col++)
                    {
                        if (IsInRadius(row, col, r, c, radius))
                        {
                            stairs[row][col] = ' ';
                          
                        }
                    }
                }
                
            }
        }

        private static bool IsInRadius(int checkRow, int checkCol, int impactRow, int impactCol, int shotRadius)
        {    
            int deltaRow = checkRow - impactRow;
            int deltaCol = checkCol - impactCol;

            bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= shotRadius * shotRadius;

            return isInRadius;
        }

        private static void FillStairs(string snake)
        {
            Queue<char> queue = new Queue<char>(snake.ToCharArray());
            stairs = new char[dimensions[0]][];
            bool isOdd = true;
            for (int row = stairs.GetLength(0) - 1; row >= 0 ; row--)
            {
                stairs[row] = new char[dimensions[1]];
                if (isOdd)
                {
                    for (int col = stairs[row].Length -1; col >= 0 ; col--)
                    {
                        stairs[row][col] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
                else
                {
                    for (int col = 0; col < stairs[row].Length; col++)
                    {
                        stairs[row][col] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
                isOdd = !isOdd;
            }

        }
    }
}
