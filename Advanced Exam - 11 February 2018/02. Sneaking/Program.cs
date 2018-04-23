using System;
using System.Linq;

namespace _02._Sneaking
{
    class Program
    {
        static char[][] matrix;
        static bool isDie = false;
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            matrix = new char[dimensions][];
            for (int row = 0; row < dimensions; row++)
            {
                string input = Console.ReadLine();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
            Command();

           // string commands = Console.ReadLine();
           //
           // for (int i = 0; i < commands.Length; i++)
           // {
           //     MoveEnemies();
           //     
           //     if (isDie)
           //     {
           //         PrintMatrix();
           //         return;
           //     }
           //     MoveSam(commands[i]);
           //    
           //     if (isDie)
           //     {
           //         PrintMatrix();
           //         return;
           //     }
           // }






        }

        private static void Command()
        {
            char command = char.Parse(Console.ReadLine());
            while (command == 'F')
            {
                MoveEnemies();
                PrintMatrix();
                Console.WriteLine();
                if (isDie)
                {
                    PrintMatrix();
                    return;
                }
                MoveSam(command);
                PrintMatrix();
                Console.WriteLine(new string('-', 30));
                if (isDie)
                {
                    PrintMatrix();
                    return;
                }
            }
        }

        private static void MoveSam(char v)
        {
            bool isMove = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        switch (v)
                        {
                            case 'U':
                                MoveUp(row, col);
                                isMove = true;
                                break;
                            case 'L':
                                MoveLeft(row, col);
                                isMove = true;
                                break;
                            case 'R':
                                MoveRigth(row, col);
                                isMove = true;
                                break;
                            case 'D':
                                MoveDown(row, col);
                                isMove = true;
                                break;
                            case 'W':
                                break;

                        }
                    }
                    if (isMove)
                    {
                        break;
                    }
                }
                if (isMove)
                {
                    break;
                }
            }
        }

        private static void MoveDown(int row, int col)
        {
            for (int c = 0; c < matrix[row].Length; c++)
            {
                if ((c < col && matrix[row + 1][c] == 'b') || (c > col && matrix[row + 1][c] == 'd'))
                {
                    isDie = true;
                    Console.WriteLine($"Sam died at {row + 1}, {col}");
                    matrix[row + 1][col] = 'X';
                    matrix[row][col] = '.';
                    break;
                }
                else if (matrix[row + 1][c] == 'N')
                {
                    Console.WriteLine($"Nikoladze killed!");
                    matrix[row + 1][c] = 'X';
                    isDie = true;
                }
                else
                {
                    matrix[row][col] = '.';
                    matrix[row + 1][col] = 'S';
                    c++;
                }
            }
        }

        private static void MoveRigth(int row, int col)
        {
            matrix[row][col] = '.';
            matrix[row][col + 1] = 'S';
        }

        private static void MoveLeft(int row, int col)
        {
            matrix[row][col - 1] = 'S';
            matrix[row][col] = '.';
        }

        private static void MoveUp(int row, int col)
        {
            for (int c = 0; c < matrix[row - 1].Length; c++)
            {
                if ((c < col && matrix[row - 1][c] == 'b') || (c > col && matrix[row - 1][c] == 'd'))
                {
                    isDie = true;
                    Console.WriteLine($"Sam died at {row - 1}, {col}");
                    matrix[row - 1][col] = 'X';
                    matrix[row][col] = '.';
                    break;
                }
                else if (matrix[row - 1][c] == 'N')
                {
                    Console.WriteLine($"Nikoladze killed!");
                    matrix[row - 1][c] = 'X';
                    isDie = true;
                }
                else
                {
                    matrix[row][col] = '.';
                    matrix[row - 1][col] = 'S';
                }
            }
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        MoveB(row, col);
                        break;
                    }
                    if (matrix[row][col] == 'd')
                    {
                        MoveD(row, col);
                        break;
                    }
                }
            }
        }

        private static void MoveD(int row, int col)
        {
            if (col == 0)
            {
                matrix[row][col] = 'b';
                for (int c = 1; c < matrix[row].Length; c++)
                {
                    if (matrix[row][c] == 'S')
                    {
                        Console.WriteLine($"Sam died at {row}, {c}");
                        matrix[row][c] = 'X';
                        isDie = true;
                    }
                }
            }
            else
            {
                matrix[row][col] = '.';
                matrix[row][col - 1] = 'd';
            }
        }

        private static void MoveB(int row, int col)
        {
            if (col == matrix[row].Length - 1)
            {
                matrix[row][col] = 'd';
                for (int c = 0; c < matrix[row].Length - 1; c++)
                {
                    if (matrix[row][c] == 'S')
                    {
                        Console.WriteLine($"Sam died at {row}, {c}");
                        matrix[row][c] = 'X';
                        isDie = true;
                    }
                }
            }
            else
            {
                matrix[row][col] = '.';
                matrix[row][col + 1] = 'b';
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
