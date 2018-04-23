using System;
using System.Collections.Generic;
using System.Linq;
namespace _13.Crossfire
{
    class Program
    {
        static int[] dimensions;
        static List<int[]> temp = new List<int[]>();
        static void Main()
        {
            dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            FillMatrix();         
            string input = Console.ReadLine();
            while(input != "Nuke it from orbit")
            {
                int[] inputTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                
                int r = inputTokens[0];
                int c = inputTokens[1];
                int rad = inputTokens[2];

                Fire(r, c, rad);
                Clean();
                
                input = Console.ReadLine();
            }
            PrintMatrix();
        }

        private static void Clean()
        {
            for (int row = 0; row < temp.Count; row++)
            {
                temp[row] = temp[row].Where(x => x != 0).ToArray();                
            }
            temp = temp.Where(x => x.Length != 0).ToList();            
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < temp.Count; row++)
            {
                    Console.WriteLine(string.Join(" ", temp[row]));                       
            }
        }

        private static void Fire(int r, int c, int rad)
        {
            for (int row = 0; row < temp.Count; row++)
            {
                for (int col = 0; col < temp[row].Length; col++)
                {
                    if (IsInFire(row, col, r, c, rad))
                    {
                        temp[row][col] = 0;
                    }
                }
            }
        }

        private static bool IsInFire(int row, int col, int r, int c, int rad)
        {
            if ((row >= r - rad && row <= r + rad && col == c) || (col >= c - rad && col <= c + rad && row == r))
            {
                return true;
            }
            return false;
        }

        private static void FillMatrix()
        {
            int count = 1;
            for (int row = 0; row < dimensions[0]; row++)
            {
                temp.Add(new int[dimensions[1]]);
                for (int col = 0; col < dimensions[1]; col++)
                {
                    temp[row][col] = count++;
                }
            }
        }
    }
}
