using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    stack.Push(input[i]);
                }
                else if (input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                else if (input[i] == '(')
                {
                    stack.Push(input[i]);
                }
                else if (input[i] == ')')
                {
                    if  (stack.Count > 0 && stack.Pop() == '(')
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == '}')
                {
                    if (stack.Count > 0 && stack.Pop() == '{')
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == ']')
                {
                    if (stack.Count > 0 && stack.Pop() == '[')
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
