using System;
using System.Linq;

namespace _12.Radioactive_Bunnies
{
    class Program
    {
        static char[][] matrix;
        static int[] dimensions;
        static bool isFinished = false;
        static int x = 0;
        static int y = 0;
        static bool isDead = false;
        static void Main()
        {
            dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            matrix = new char[dimensions[0]][];

            FillMatrix();

            Commands();

            PrintResult();


        }

        private static void PrintResult()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
            if (isDead)
            {
                Console.WriteLine($"dead: {x} {y}");
            }
            else
            {
                Console.WriteLine($"won: {x} {y}");
            }
        }

        private static void Commands()
        {
            string command = Console.ReadLine();

            for (int i = 0; i < command.Length; i++)
            {
                switch (command[i])
                {
                    case 'L':
                        MoveLeft();
                        break;
                    case 'R':
                        MoveRight();
                        break;
                    case 'U':
                        MoveUp();
                        break;
                    case 'D':
                        MoveDown();
                        break;
                }
                Propagation();
                if (isFinished)
                {
                    return;
                }
            }          
        }

        private static void Propagation()
        {
            char[][] temp = new char[dimensions[0]][];
            for (int row = 0; row < dimensions[0]; row++)
            {
                if (temp[row] == null)
                {
                    temp[row] = new char[dimensions[1]];
                }
               
                for (int col = 0; col < dimensions[1]; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        temp[row][col] = matrix[row][col];
                        for (int r = 0; r < temp.GetLength(0); r++)
                        {
                            if (temp[r] == null)
                            {
                                temp[r] = new char[dimensions[1]];
                            }
                          
                            for (int c = 0; c < temp[r].Length; c++)
                            {
                                if (IsNear(row, col, r, c) && matrix[r][c] != 'P')
                                {
                                    temp[r][c] = 'B';
                                }
                                else if (IsNear(row, col, r, c) && matrix[r][c] == 'P')
                                {
                                    temp[r][c] = 'B';
                                    isFinished = true;
                                    isDead = true;
                                    x = r;
                                    y = c;
                                }
                               
                            }
                        }
                    }
                    else if(temp[row][col] != 'B')
                    {
                        temp[row][col] = matrix[row][col];
                    }
                }
            }
            matrix = temp;          
        }

        private static bool IsNear(int row, int col, int r, int c)
        {
            if ((r == row && c - 1 == col) || (r == row && c + 1 == col) || (r - 1 == row && c == col) || (r + 1 == row && c == col))
            {
                return true;
            }
            return false;
        }

        private static void MoveDown()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        if (row == matrix.GetLength(0) - 1)
                        {
                            matrix[row][col] = '.';
                            isDead = false;
                            isFinished = true;
                            x = row;
                            y = col;
                            return;                     
                        }
                        else if (matrix[row + 1][col] != 'B')
                        {
                            matrix[row + 1][col] = 'P';
                            matrix[row][col] = '.';
                        }
                        else
                        {
                            matrix[row][col] = '.';
                            isFinished = true;
                            isDead = true;
                            x = row + 1;
                            y = col;                        
                        }
                    }
                }
            }
        }

        private static void MoveUp()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        if (row == 0)
                        {
                            matrix[row][col] = '.';
                            isDead = false;
                            isFinished = true;
                            x = row;
                            y = col;                          
                        }
                        else if (matrix[row - 1][col] != 'B')
                        {
                            matrix[row - 1][col] = 'P';
                            matrix[row][col] = '.';
                        }
                        else
                        {
                            matrix[row][col] = '.';
                            isDead = true;
                            isFinished = true;
                            x = row - 1;
                            y = col;
                        }
                    }
                }
            }
        }

        private static void MoveRight()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        if (col == matrix[row].Length - 1)
                        {
                            matrix[row][col] = '.';
                            isDead = false;
                            isFinished = true;
                            x = row;
                            y = col;                          
                        }
                        else if (matrix[row][col + 1] != 'B')
                        {
                            matrix[row][col + 1] = 'P';
                            matrix[row][col] = '.';
                        }
                        else
                        {
                            matrix[row][col] = '.';
                            isDead = true;
                            isFinished = true;
                            x = row;
                            y = col + 1;
                        }
                    }
                }
            }
        }

        private static void MoveLeft()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        if (col == 0)
                        {
                            matrix[row][col] = '.';
                            isDead = false;
                            isFinished = true;
                            x = row;
                            y = col;                          
                        }
                        else if (matrix[row][col - 1] != 'B')
                        {
                            matrix[row][col - 1] = 'P';
                            matrix[row][col] = '.';
                        }
                        else
                        {
                            
                            matrix[row][col] = '.';
                            isDead = true;
                            isFinished = true;
                            x = row;
                            y = col - 1;
                        }
                    }
                }
            }
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = new char[dimensions[1]];

                string input = Console.ReadLine().Trim();

                for (int col = 0; col < dimensions[1]; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
        }
    }
}
