using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main()
        {
            Func<int, bool> parityFunc = n => n % 2 != 0;

            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(n => parityFunc(n))
                .ThenBy(n => n)
                .ToList()
                .ForEach(n => Console.Write($"{n} "));
        }
    }
}
