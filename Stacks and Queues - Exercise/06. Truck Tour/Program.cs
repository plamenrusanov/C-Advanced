using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Queue<long> petrol = new Queue<long>();
            Queue<long> distance = new Queue<long>();

            for (int i = 0; i < N; i++)
            {
                long[] pump = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

                petrol.Enqueue(pump[0]);
                distance.Enqueue(pump[1]);
            }

            long p;
            long d;

            for (int i = 0; i < N; i++)
            {
                bool isPass = true;
                p = 0;
                d = 0;
                for (int k = 0; k < N; k++)
                {
                    p += petrol.Peek();
                    d += distance.Peek();
                    if (p < d)
                    {
                        isPass = false;
                    }
                    petrol.Enqueue(petrol.Dequeue());
                    distance.Enqueue(distance.Dequeue());
                }
                if (isPass)
                {
                    Console.WriteLine(i);
                    return;
                }
                petrol.Enqueue(petrol.Dequeue());
                distance.Enqueue(distance.Dequeue());
            }
        }
    }
}
