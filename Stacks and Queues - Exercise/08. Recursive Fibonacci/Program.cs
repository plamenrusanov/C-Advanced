using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            decimal fib = Fibonacci(num);
            Console.WriteLine(fib);
            
        }

        const int MAX_FIBОNACCI_SEQUENCE_MEMBER = 1000;
        static decimal[] fib = new decimal[MAX_FIBОNACCI_SEQUENCE_MEMBER];

        static decimal recursiveCallsCounter = 0;

        static decimal Fibonacci(int n)
        {
            recursiveCallsCounter++;
            if (fib[n] == 0)
            {
                // The value of fib[n] is still not calculated -> calculate it now
                if ((n == 1) || (n == 2))
                {
                    fib[n] = 1;
                }
                else
                {
                    fib[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
                }
            }
            return fib[n];
        }
    }
}


