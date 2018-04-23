using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main()
        {
            var words = new Dictionary<string, int>();
            using (StreamReader streamReader = new StreamReader("..\\Resources\\word.txt"))
            {
                string word;
                while ((word = streamReader.ReadLine()) != null)
                {
                    if (!words.ContainsKey(word))
                    {
                        words.Add(word, 0);
                    }
                }
            }

            using (StreamReader stream = new StreamReader("..\\Resources\\text.txt"))
            {
                string token;
                while ((token = stream.ReadLine()) != null)
                {
                    string[] tokens = token.Split(new char[] { ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < tokens.Length; i++)
                    {
                        string temp = tokens[i].ToLower();
                        if (words.ContainsKey(temp))
                        {
                            words[temp]++;
                        }
                    }
                }              
            }

            using(StreamWriter streamWriter = new StreamWriter(".\\result.txt"))
            {
                foreach (var item in words.OrderByDescending(x => x.Value))
                {
                    streamWriter.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
