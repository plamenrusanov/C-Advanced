using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJudge
{
    class SimpleJudge
    {
        static void Main(string[] args)
        {
            Tester.CompareContent(@"C:\SimpleJudge\actual.txt", @"C:\SimpleJudge\expected.txt");
        }
    }
}
