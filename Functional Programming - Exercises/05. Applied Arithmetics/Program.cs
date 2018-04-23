using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    public static class Functions
    {
        public static void Print(List<int> collection, Action<List<int>> action)
        {
            action(collection);
        }

        public static List<int> MyFunc (List<int> collection, Func<int, int> func)
        {
            List<int> result = new List<int>();

            foreach (var item in collection)
            {
                result.Add(func(item));
            }
            return result;
        }
    }
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = Functions.MyFunc(numbers, x => x + 1);
                        break;
                    case "subtract":
                        numbers = Functions.MyFunc(numbers, x => x - 1);
                        break;
                    case "multiply":
                        numbers = Functions.MyFunc(numbers, x => x * 2);
                        break;
                    case "print":
                        Functions.Print(numbers, x => Console.WriteLine(string.Join(" ", x)));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
