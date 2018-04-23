using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> elements = new Queue<long>();

            long dequeueCount = 50;

            elements.Enqueue(n);

            for (int i = 0; i < dequeueCount; i++)
            {
                var currentElement = elements.Dequeue();
                Console.Write($"{currentElement} ");
                elements.Enqueue(currentElement + 1);
                elements.Enqueue(currentElement * 2 + 1);
                elements.Enqueue(currentElement + 2);
            }
            Console.WriteLine();
        }
    }
}
