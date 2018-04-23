using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    public static class Predicats
    {

    }
    class Program
    {
       

        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= upperBound; i++)
            {
                bool isDivide = true;
                for (int j = 0; j < dividers.Length; j++)
                {
                    if (!(i % dividers[j] == 0))
                    {
                        isDivide = false;
                    }
                }
                if (isDivide)
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
