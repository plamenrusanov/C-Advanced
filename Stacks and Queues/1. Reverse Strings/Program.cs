using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                result += stack.Pop();
            }

            Console.WriteLine(result);

        }
    }
}
