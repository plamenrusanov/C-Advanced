using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            while (stack.Count <= n)
            {
                long n1 = stack.Pop();
                long n2 = stack.Peek();
                long currentNumber = n1 + n2;
                stack.Push(n1);
                stack.Push(currentNumber);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}
