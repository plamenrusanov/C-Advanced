using System;
using System.Linq;

namespace Lab
{
    class Program
    {
        static void Main()
        {
            Predicate<int> d = x => x > 0;
            var numbers = Console.ReadLine().Split(", ")
                .Select(int.Parse);
          //   int sum = numbers.Sum();
          //  Func<int, bool> func = n => n % 2 == 0;
          //  Console.WriteLine(string.Join(", ", numbers.SkipWhile(n => n < 3)));
          //  Console.WriteLine(string.Join(", ", numbers.Where(func)));
            numbers = numbers.AsQueryable();
            if (true)
            {
                numbers = numbers.Where(n => n > 2);
            }
            if (true)
            {
                numbers = numbers.Where(n => n % 2 == 0);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
