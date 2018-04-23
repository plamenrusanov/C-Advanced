using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            stack.Push(int.MinValue);
            var maxNum = new Stack<int>();
            maxNum.Push(int.MinValue);
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    stack.Push(input[1]);
                    if (maxNum.Peek() < input[1])
                    {
                        maxNum.Push(input[1]);
                    }
                }
                else if (input[0] == 2)
                {
                    if (maxNum.Peek() == stack.Pop())
                    {
                        maxNum.Pop();
                    }
                }
                else 
                {
                    Console.WriteLine(maxNum.Peek());
                }
            }
        }
    }
}
