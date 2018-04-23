using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
          
            int n = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();
            string str = string.Empty;
            stack.Push(str);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string key = input[0];
                if (key == "1")
                {
                    str += input[1];
                    stack.Push(str);
                }
                else if (key == "2")
                {
                    int lengthToRemove = int.Parse(input[1]);
                    str = str.Remove(str.Length - lengthToRemove);                  
                    stack.Push(str);
                }
                else if (key == "3")
                {
                    int index = int.Parse(input[1]);    
                    Console.WriteLine(str[index - 1]);
                }
                else if (key == "4")
                {
                    stack.Pop();
                    str = stack.Peek();
                  
                }
               
            }


        }
    }
}
