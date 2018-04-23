using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();          
            var stack = new Stack<int>();
            for (int i = 0; i < 10000; i++)
            {
                stack.Push(i);
            }
            watch.Stop();
            Console.WriteLine($"Stack.Push: {watch.ElapsedTicks}");
           

            var list = new List<int>();
            watch.Reset();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(i);
            }
            watch.Stop();
            Console.WriteLine($"List.Add: {watch.ElapsedTicks}");

            watch.Reset();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                int n = stack.Count;
               
            }
            watch.Stop();
            Console.WriteLine($"Stack.Count: {watch.ElapsedTicks}");

            watch.Reset();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                int n = list.Count;
            }
            watch.Stop();
            Console.WriteLine($"List.Count: {watch.ElapsedTicks}");

            watch.Reset();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                int n = stack.Max();              
            }
            watch.Stop();
            Console.WriteLine($"Stack.Max: {watch.ElapsedTicks}");

            watch.Reset();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                list.Max();
            }
            watch.Stop();
            Console.WriteLine($"List.Max: {watch.ElapsedTicks}");

            watch.Reset();
            bool isContains;
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                isContains = stack.Contains(i);
            }
            watch.Stop();
            Console.WriteLine($"Stack.Contains: {watch.ElapsedTicks}");

            watch.Reset();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                isContains = list.Contains(i);
            }
            watch.Stop();
            Console.WriteLine($"List.Contains: {watch.ElapsedTicks}");

            watch.Reset();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                stack.Pop();
            }
            watch.Stop();
            Console.WriteLine($"Stack.Pop: {watch.ElapsedTicks}");

            watch.Reset();
            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                list.Remove(i);
            }
            watch.Stop();
            Console.WriteLine($"List.Remove: {watch.ElapsedTicks}");
        }
    }
}
