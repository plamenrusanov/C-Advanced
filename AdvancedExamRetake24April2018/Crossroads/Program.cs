using System;
using System.Collections;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            int green = int.Parse(Console.ReadLine());
            int free = int.Parse(Console.ReadLine());
            int carsPassedCount = 0;
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                int secondsLeft = green;
                if (input.Equals("green"))
                {
                    while (queue.Count > 0)
                    {
                        string car = (string)queue.Dequeue();
                        carsPassedCount++;
                      
                        if (secondsLeft == car.Length)
                        {
                            secondsLeft -= car.Length;
                            break;
                        }
                        else if (secondsLeft > car.Length)
                        {
                            secondsLeft -= car.Length;
                            continue;
                        }
                        else
                        {
                            if (secondsLeft + free >= car.Length)
                            {
                                break;
                            }
                            int index = Math.Abs(secondsLeft) + free;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {car[index]}.");
                            return;
                        }

                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassedCount} total cars passed the crossroads.");
        }
    }
}
