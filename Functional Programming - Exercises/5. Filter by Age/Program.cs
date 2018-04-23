using System;
using System.Collections.Generic;

namespace _5._Filter_by_Age
{
    class Program
    {
        static Func<int, bool> GetFillter (string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var data = new Dictionary<string, int>(n);
            for (int i = 0; i < n; i++)
            {
                var nameAndAge = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                data.Add(nameAndAge[0], int.Parse(nameAndAge[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            var filter = GetFillter(condition, age);
            var printer = CreatePrinter(format);
            PrintPeople(data, filter, printer);

        }

        private static void PrintPeople(Dictionary<string, int> data, Func<int, bool> filter, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var item in data)
            {
                if (filter(item.Value))
                {
                    printer(item);
                }
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
