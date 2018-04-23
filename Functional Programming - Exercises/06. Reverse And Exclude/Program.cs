using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int divider = int.Parse(Console.ReadLine());

            numbers = numbers.Where(n => n % divider != 0).Reverse().ToList();
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
