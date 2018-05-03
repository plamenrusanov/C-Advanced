using System;
using System.Linq;

namespace ParkingFeud
{
    class Program
    {
        //static int[][] matrix;
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
           // InitializeMatrix(dimensions);
            int totalDistance = 0;
            int samsRow = int.Parse(Console.ReadLine()) - 1;
            while (true)
            {
                string[] lots = Console.ReadLine().Split();
                bool isAnyCarHaveSameParkingLot = IsAnyCarHaveSameParkingLot(lots, samsRow);
                string parkingLot = lots[samsRow];

                if (!isAnyCarHaveSameParkingLot)
                {
                    int distance = CalculateDistance(dimensions, samsRow, parkingLot);
                    totalDistance += distance;
                    PrintResult(totalDistance, parkingLot);
                    return;
                }
                else
                {
                    int samsDistance = CalculateDistance(dimensions, samsRow, parkingLot);
                    int otherIndex = OtherCarIndex(lots, samsRow, parkingLot);
                    int otherDistance = CalculateDistance(dimensions, otherIndex, parkingLot);
                    if (samsDistance <= otherDistance)
                    {
                        totalDistance += samsDistance;
                        PrintResult(totalDistance, parkingLot);
                        return;
                    }

                    totalDistance += samsDistance * 2;
                }
            }


        }

        private static int OtherCarIndex(string[] lots, int samsRow, string parkingLot)
        {
            int otherIndex = 0;
            for (int i = 0; i < lots.Length; i++)
            {
                if (samsRow != i && lots[i].Equals(parkingLot))
                {
                    otherIndex = i;
                }
            }
            return otherIndex;
        }

        private static void PrintResult(int totalDistance, string parkingLot)
        {
            Console.WriteLine($"Parked successfully at {parkingLot}.");
            Console.WriteLine($"Total Distance Passed: {totalDistance}");
        }

        private static int CalculateDistance(int[] dimensions, int samsRow, string parkingLot)
        {
            int colDimension = dimensions[1];
            char column = parkingLot[0];
            int row = int.Parse(parkingLot[1].ToString());
            int result = 0;
            if (samsRow == row || samsRow - row == -1)
            {
                result = MoveFromLeft(column);
            }
            else if (samsRow - row > 0)
            {
                int diffRows = Math.Abs(samsRow - row) + 1;
                if (diffRows % 2 == 0)
                {
                    result = MoveRows(diffRows, colDimension) + MoveFromLeft(column);
                }
                else
                {
                    result = MoveRows(diffRows, colDimension) + MoveFromRigth(column, colDimension);
                }
            }
            else
            {
                int diffRows = Math.Abs(samsRow - row) - 2;
                if (diffRows % 2 == 0)
                {
                    result = MoveRows(diffRows, colDimension) + MoveFromLeft(column);
                }
                else
                {
                    result = MoveRows(diffRows, colDimension) + MoveFromRigth(column, colDimension);
                }
            }
            return result;

        }

        private static int MoveFromRigth(char column, int v)
        {
            return (v - ((int)column - 65));
        }

        private static int MoveRows(int diffRows, int v)
        {
            return (diffRows * (v + 3));
        }

        private static int MoveFromLeft(char column)
        {
           return ((int)column - 64);
        }

        private static bool IsAnyCarHaveSameParkingLot(string[] lots, int samsRow)
        {
            int count = 0;
            string parkingLot = lots[samsRow];
            foreach (var item in lots)
            {
                if (item.Equals(parkingLot))
                {
                    count++;
                }
            }
            return count >= 2;
        }

        //private static void InitializeMatrix(int[] dimensions)
        //{
        //    matrix = new int[dimensions[0] * 2 - 1][];
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        matrix[i] = new int[dimensions[1] + 2];
        //    }
        //}
    }
}
