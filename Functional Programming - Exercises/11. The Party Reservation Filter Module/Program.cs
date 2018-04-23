using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    public static class Function
    {
        public static Func<string, string, bool> Contains = (s, c) => s.Contains(c);

        public static Func<string, string, bool> EndWith = (s, c) => s.EndsWith(c);

        public static Func<string, string, bool> StartWith = (s, c) => s.StartsWith(c);

        public static Func<string, int, bool> Length = (s, c) => s.Length == c;

        public static List<string> DoubleLength(List<string> people, Func<string, int, bool> func, int length)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < people.Count; i++)
            {
                result.Add(people[i]);
                if (func(people[i], length))
                {
                    result.Add(people[i]);
                }
            }
            return result;
        }

        public static List<string> With(List<string> people, Func<string, string, bool> func, string s)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < people.Count; i++)
            {
                result.Add(people[i]);
                if (func(people[i], s))
                {
                    result.Add(people[i]);
                }
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command;
            var dataCommand = new Dictionary<string, List<string>>();
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] token = command.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (token[0] == "Add filter")
                {
                    if (!dataCommand.ContainsKey(token[1]))
                    {
                        dataCommand.Add(token[1], new List<string>());
                    }
                    dataCommand[token[1]].Add(token[2]);
                }
                else
                {
                    if (dataCommand.ContainsKey(token[1]) && dataCommand[token[1]].Contains(token[2]))
                    {
                        dataCommand[token[1]].Remove(token[2]);
                    }
                }
               
            }

            foreach (var item in dataCommand)
            {
                foreach (string str in item.Value)
                {
                    switch (item.Key)
                    {
                        case "Starts with":
                            people = people.Where(p => !(Function.StartWith(p, str))).ToList();
                            break;
                        case "Ends with":
                            people = people.Where(p => !(Function.EndWith(p, str))).ToList();
                            break;
                        case "Contains":
                            people = people.Where(p => !(Function.Contains(p, str))).ToList();
                            break;
                        case "Length":
                            people = people.Where(p => !(Function.Length(p, int.Parse(str)))).ToList();
                            break;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}
