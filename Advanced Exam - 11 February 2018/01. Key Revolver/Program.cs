using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int ginBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] lockses = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();
            int inteligence = int.Parse(Console.ReadLine());
            Queue<int> bulets = new Queue<int>(bullets.Reverse());
            Stack<int> locks = new Stack<int>(lockses.Reverse());
            int chootCount = 0;
            while (locks.Count != 0)
            {
                chootCount++;
                int bulet = bulets.Dequeue();
                if (bulet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (bulets.Count != 0 && chootCount % ginBarrel == 0)
                {
                    Console.WriteLine("Reloading!");
                }
                if (locks.Count != 0 && bulets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

            }
            int cost = priceOfBullet * chootCount;
            Console.WriteLine($"{bulets.Count} bullets left. Earned ${inteligence - cost}");
        }
    }
}
