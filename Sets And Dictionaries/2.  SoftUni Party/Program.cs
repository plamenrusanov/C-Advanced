using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2.SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            string input = Console.ReadLine();
            var chekingList = new SortedSet<string>();
            while (input != "PARTY")
            {
                chekingList.Add(input);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                chekingList.Remove(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(chekingList.Count);
            foreach (var item in chekingList)
            {
                Console.WriteLine(item);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
