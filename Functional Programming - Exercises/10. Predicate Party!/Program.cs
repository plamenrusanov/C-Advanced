using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    public static class Function
    {
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
        static void Main()
        {
            List<string> people = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Remove")
                {
                    if (tokens[1] == "Length")
                    {
                        people = people.Where(x => !(Function.Length(x, int.Parse(tokens[2])))).ToList();
                    }
                    else if (tokens[1] == "EndsWith")
                    {
                        people = people.Where(x => !(Function.EndWith(x, tokens[2]))).ToList();
                    }
                    else
                    {
                        people = people.Where(x => !(Function.StartWith(x, tokens[2]))).ToList();
                    }
                }
                else
                {
                    if (tokens[1] == "Length")
                    {
                        people = Function.DoubleLength(people, Function.Length, int.Parse(tokens[2]));
                    }
                    else if (tokens[1] == "EndsWith")
                    {
                        people = Function.With(people, Function.EndWith, tokens[2]);
                    }
                    else
                    {
                        people = Function.With(people, Function.StartWith, tokens[2]);
                    }
                }
            }
            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            
        }
    }
}
