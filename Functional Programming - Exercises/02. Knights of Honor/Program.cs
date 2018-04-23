using System;

namespace Problem_1._Action_Point
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = message => Console.WriteLine($"Sir {message}");
            foreach (var item in input)
            {
                print(item);
            }
        }

    }
}
