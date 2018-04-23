using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.MathPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputToken = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(inputToken);
            int cycle = 1;
            while (queue.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());                   
                }
                if (isPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                cycle++;             
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        private static bool isPrime(int cycle)
        {
            if (cycle == 1) return false;
            if (cycle == 2) return true;

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(cycle)); ++i)
            {
                if (cycle % i == 0) return false;
            }

            return true;
        }
    }
}
