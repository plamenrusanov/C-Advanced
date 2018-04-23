using System;
using System.Collections.Generic;

namespace _02._Knight_Game
{
    class Program
    {
        static char[][] board;
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());

            board = new char[dimension][];

            for (int row = 0; row < dimension; row++)
            {
                board[row] = new char[dimension];
                string input = Console.ReadLine();
                for (int col = 0; col < dimension; col++)
                {
                    board[row][col] = input[col];
                }
            }
            Stack<int> knight = new Stack<int>();
            int maxElement = 1;
            int count = 0;
            while (maxElement >= 1)
            {
                maxElement = 0;
                //var matrix = new int[dimension][];
                for (int row = 0; row < dimension; row++)
                {
                    //matrix[row] = new int[dimension];
                    for (int col = 0; col < dimension; col++)
                    {
                        if (board[row][col] == 'K')
                        {
                            int currentPower = IsOtherKnight(row, col);
                            //matrix[row][col] = currentPower;
                            if (currentPower > maxElement)
                            {
                                maxElement = currentPower;
                                knight.Push(col);
                                knight.Push(row);
                            }
                        }
                    }
                }
                if (maxElement != 0)
                {
                    board[knight.Pop()][knight.Pop()] = '0';
                    count++;
                   // PrintMatrix();
                }
               
            }
            Console.WriteLine(count);
           // Console.WriteLine($"Max: {maxElement} - row {knight.Pop()} - col {knight.Pop()}");
         
        }

        private static void PrintMatrix()
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board[r].Length; c++)
                {
                    Console.Write(board[r][c] + " ");
                }
                Console.WriteLine();
            }
        }

        private static byte IsOtherKnight(int row, int col)
        {
            byte count = 0;
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board[r].Length; c++)
                {
                    if (IsPosition(row, col, r, c) && board[r][c] == 'K')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static bool IsPosition(int row, int col, int r, int c)
        {
            int rowDiff = Math.Abs(row - r);
            int colDiff = Math.Abs(col - c);
            if ((rowDiff == 1 && colDiff == 2) || (rowDiff == 2 && colDiff == 1))
            {
                return true;
            }
            return false;
        }
    }
}

