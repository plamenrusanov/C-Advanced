using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int infoIndex = int.Parse(Console.ReadLine());
            var data = new Dictionary<string, Dictionary<string, string>>();
            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] tokens = input.Split(new char[] { '=', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                if (!data.ContainsKey(name))
                {
                    data.Add(name, new Dictionary<string, string>());
                }
                for (int i = 1; i < tokens.Length; i+=2)
                {
                    string key = tokens[i];
                    string value = tokens[i + 1];
                    if (!data[name].ContainsKey(key))
                    {
                        data[name].Add(key, value);
                    }
                    else
                    {
                        data[name][key] = value;
                    }
                    
                }
            }
            string[] readName = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int currentIndex = 0;
            foreach (var item in data.Where(x => x.Key == readName[1]))
            {
                Console.WriteLine($"Info on {item.Key}:");
                foreach (var kvp in item.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
                    currentIndex += (kvp.Key.Length + kvp.Value.Length);
                }
                
            }
            Console.WriteLine($"Info index: {currentIndex}");
            if (currentIndex >= infoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {infoIndex - currentIndex} more info.");
            }
        }
    }
}
