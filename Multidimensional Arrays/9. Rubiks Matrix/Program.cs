using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.Rubiks_Matrix
{
    class Program
    {
        static int[] sizeMatrix;
        static int[][] matrix;
        static void Main()
        {
            FillMatrix();
            Command();
            Rearrange();
        }

        private static void Rearrange()
        {
            int number = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == number)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.GetLength(0); r++)
                        {
                            for (int c = 0; c < matrix[r].Length; c++)
                            {
                                if (matrix[r][c] == number)
                                {
                                    int temp = matrix[row][col];
                                    matrix[row][col] = matrix[r][c];
                                    matrix[r][c] = temp;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                }
                            }
                        }
                    }
                    number++;
                }
            }
        }

        private static void FillMatrix()
        {
            sizeMatrix = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse).ToArray();

            matrix = new int[sizeMatrix[0]][];
            int n = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[sizeMatrix[1]];
                for (int col = 0; col < sizeMatrix[1]; col++)
                {
                    matrix[row][col] = n++;
                }
            }
        }

        private static void Command()
        {
            int countCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < countCommand; i++)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int rc = int.Parse(command[0]);
                string direction = command[1];
                int moves = int.Parse(command[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(rc, moves);
                        break;
                    case "down":
                        MoveDown(rc, moves);
                        break;
                    case "left":
                        MoveLeft(rc, moves);
                        break;
                    case "right":
                        MoveRight(rc, moves);
                        break;
                }
            }
        }

        private static void MoveRight(int rc, int moves)
        {
            moves = moves % matrix.GetLength(0);
            Queue<int> queue = new Queue<int>(matrix[rc]);
            for (int j = 0; j < queue.Count - moves; j++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            matrix[rc] = queue.ToArray();
        }

        private static void MoveLeft(int rc, int moves)
        {
            moves = moves % matrix.GetLength(0);
            Queue<int> queue = new Queue<int>(matrix[rc]);
            for (int j = 0; j < moves; j++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            matrix[rc] = queue.ToArray();
        }

        private static void MoveDown(int rc, int moves)
        {
            moves = moves % sizeMatrix[1];
            Queue<int> queue = new Queue<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                queue.Enqueue(matrix[row][rc]);
            }
            for (int i = 0; i < sizeMatrix[1] - moves; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row][rc] = queue.Dequeue();
            }
        }

        private static void MoveUp(int rc, int moves)
        {
            moves = moves % sizeMatrix[1];
            Queue<int> queue = new Queue<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                queue.Enqueue(matrix[row][rc]);
            }
            for (int i = 0; i < moves; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row][rc] = queue.Dequeue();
            }
        }

    }
}
