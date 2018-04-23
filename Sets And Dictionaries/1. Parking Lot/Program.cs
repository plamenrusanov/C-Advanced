using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1.Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var parking = new SortedSet<string>();
            while (input != "END")
            {
                string[] tokens = Regex.Split(input, ", ");
                if (tokens[0] == "IN")
                {
                    parking.Add(tokens[1]);
                }
                else
                {
                    if (parking.Contains(tokens[1]))
                    {
                        parking.Remove(tokens[1]);
                    }
                   
                }
                input = Console.ReadLine();
            }
            if (parking.Count != 0)
            {
                foreach (var item in parking)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
