using System;
using System.Linq;

namespace _3.Group_Numbers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var sizeArrays = new int[3];
            for (int i = 0; i < numbers.Length; i++)
            {
                sizeArrays[Math.Abs(numbers[i] % 3)]++;
            }

            int[][] matrix = new int[3][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[sizeArrays[i]];
            }


            int[] index = new int[3];
            for (int i = 0; i < numbers.Length; i++)
            {
                int reminder = Math.Abs(numbers[i] % 3);
                matrix[reminder][index[reminder]] = numbers[i];
                index[reminder]++;
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ",matrix[row]));
            }
        }
    }
}
