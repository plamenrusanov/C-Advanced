using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputToken = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(inputToken);

            while (queue.Count > 1)
            {
                for (int i = 0; i < n -1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
