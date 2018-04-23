using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main()
        {
            int[] range = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToArray();
            string condition = Console.ReadLine();


            Filter(range, GetFillter(condition));
           
            
        }
        static void Filter (int[] range, Func<int, bool> filter)
        {
            for (int i = range[0]; i <= range[1]; i++)
            {

                if (filter(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
        static Func<int, bool> GetFillter(string cond)
        {
            if (cond == "even")
            {
                return x => x % 2 == 0;
                }
            else
            {
                return x => x % 2 != 0;
            }
        }
    }
}
