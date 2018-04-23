using System;
using System.Linq;

namespace _15._Parking_System
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];
           
            string input;

            while ((input = Console.ReadLine()) != "stop")
            {
                int[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int entrance = tokens[0];
                int r = tokens[1];
                int c = tokens[2];

                if (matrix[r, c] == 0)
                {
                    matrix[r, c] = 1;
                    
                    Console.WriteLine(Math.Abs(entrance - r) + c + 1);
                    continue;
                }

                bool isAnyFreeSpot = IsAnyFreeSpot(matrix, r);

                if(isAnyFreeSpot)
                {
                    int indexClose = 0;
                    int minDistance = int.MaxValue;

                    for (int col = 1; col < dimensions[1]; col++)
                    {
                        if (matrix[r, col] == 0)
                        {
                            int distance = Math.Abs(c - col);
                            if (minDistance > distance)
                            {
                                indexClose = col;
                                minDistance = distance;
                            }
                        }                      
                    }
                    matrix[r, indexClose] = 1;
                    Console.WriteLine(Math.Abs(entrance - r) + indexClose + 1);
                }
                else
                {
                    Console.WriteLine($"Row {r} full");
                }
            }
        }

        private static bool IsAnyFreeSpot(int[,] matrix, int r)
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (matrix[r, col] == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
