using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var Gems = new Dictionary<string, long>();
            var Cash = new Dictionary<string, long>();
            
            long gold = 0;
            long gem = 0;
            long cash = 0;
            
            long bag = long.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < input.Length; i += 2)
            {
                string asd = input[i];
                long quantity = long.Parse(input[i + 1]);
                long amount = gold + gem + cash;
                if (asd.ToLower() == "gold")
                {
                    if (bag >= amount + quantity)
                    {
                        gold += quantity;
                       
                    }
                }
                else if (asd.Length >= 4 && asd.ToLower().EndsWith("gem"))
                {
                    if (bag >= amount + quantity && gem + quantity <= gold)
                    {
                        gem += quantity;
                        if (!Gems.ContainsKey(asd))
                        {
                            Gems.Add(asd, quantity);
                        }
                        else
                        {
                            Gems[asd] += quantity;
                        }
                    }
                }
                else if (asd.Length == 3)
                {
                    if (bag >= amount + quantity && cash + quantity <= gem)
                    {
                        cash += quantity;
                        if (!Cash.ContainsKey(asd))
                        {
                            Cash.Add(asd, quantity);
                        }
                        else
                        {
                            Cash[asd] += quantity;
                        }
                    }
                }
            }
            if (gold != 0)
            {
                Console.WriteLine($"<Gold> ${gold}");
                Console.WriteLine($"##Gold - {gold}");
            }
            if (gem != 0)
            {
                Console.WriteLine($"<Gem> ${gem}");
                foreach (var item in Gems.OrderByDescending(x => x.Key))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
            if (cash != 0)
            {
                Console.WriteLine($"<Cash> ${cash}");
                foreach (var item in Cash.OrderByDescending(x => x.Key))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

       
    }
}
