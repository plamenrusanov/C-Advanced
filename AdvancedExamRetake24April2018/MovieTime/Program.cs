using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, TimeSpan>> data = new Dictionary<string, Dictionary<string, TimeSpan>>();
            string genre = Console.ReadLine();
            string length = Console.ReadLine();
            TimeSpan totalPlaylistDuration = TimeSpan.Zero;
            string input;
            while ((input = Console.ReadLine()) != "POPCORN!")
            {
                string[] tokens = input.Split('|');
                string movie = tokens[0];
                string gen = tokens[1];
                TimeSpan timeSpan = TimeSpan.Parse(tokens[2]);
                totalPlaylistDuration = totalPlaylistDuration.Add(timeSpan);
                AddMovie(data, movie, gen, timeSpan);
            }

            Dictionary<string, TimeSpan> orderedDictionary = OrderData(data, length, genre);
            Queue<KeyValuePair<string, TimeSpan>> queue = new Queue<KeyValuePair<string, TimeSpan>>(orderedDictionary);
            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();
                Console.WriteLine(temp.Key);
                input = Console.ReadLine();
                if (input.Equals("Yes"))
                {
                    Console.WriteLine($"We're watching {temp.Key} - {temp.Value}");
                    Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration}");
                    break;
                }
            }
        }

        private static Dictionary<string, TimeSpan> OrderData(Dictionary<string, Dictionary<string, TimeSpan>> data, string length, string genre)
        {
            var orderedDictionary = data.First(d => d.Key == genre).Value.
                ToDictionary(d => d.Key, d => d.Value);
            if (length.Equals("Short"))
            {
                orderedDictionary = orderedDictionary.OrderBy(d => d.Value).ThenBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);
            }
            else
            {
                orderedDictionary = orderedDictionary.OrderByDescending(d => d.Value).ThenBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);
            }
            return orderedDictionary;
        }

        private static void AddMovie(Dictionary<string, Dictionary<string, TimeSpan>> data, string movie, string gen, TimeSpan timeSpan)
        {
            if (!data.ContainsKey(gen))
            {
                data.Add(gen, new Dictionary<string, TimeSpan>());
            }
            data[gen].Add(movie, timeSpan);
        }
    }
}
