using System;
using System.IO;

namespace Problem_1._Odd_Lines
{
    class Program
    {
        static void Main()
        {
            StreamReader stream = new StreamReader("..\\Resources\\text.txt");
            string line;
            int count = 0;
            while ((line = stream.ReadLine()) != null)
            {
                if (count % 2 == 1)
                {
                    Console.WriteLine(line);
                }
                count++;
            }
            
        }
    }
}
