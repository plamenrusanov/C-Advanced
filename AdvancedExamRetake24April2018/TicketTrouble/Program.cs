using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicketTrouble
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"(\[)([^{\[]*?)(?<destination>{POT AT})([^{\[]*?){(?<seat>[A-Z]{1}[0-9]{1,2})}([^\[\]]*?)(\])|({)([^{]*?)(?<destination>\[POT AT\])([^{]*?)\[(?<seat>[A-Z]{1}[0-9]{1,2})\]([^\]]*?)(})";
            string key = Console.ReadLine();
            pattern = pattern.Replace("POT AT", key);
            string input = Console.ReadLine();

            MatchCollection collection = Regex.Matches(input, pattern);

            List<string> data = new List<string>();

            foreach (Match item in collection)
            {
                data.Add(item.Groups["seat"].Value);
            }
            if (data.Count > 2)
            {
                data = TakeSeats(data);
            }
            Console.WriteLine($"You are traveling to {key} on seats {data[0]} and {data[1]}.");
        }

        private static List<string> TakeSeats(List<string> data)
        {
            List<string> result = new List<string>();
            int count = 0;
            foreach (var item in data)
            {
                string num = item.Substring(1);
                if (data.Count(c => c.Contains(num)) == 2)
                {
                    result.Add(item);
                    foreach (var kvp in data)
                    {
                        if (kvp != item && kvp.Contains(num))
                        {
                            result.Add(kvp);
                        }
                    }
                }
              
            }

            return result;
        }
    }
}
