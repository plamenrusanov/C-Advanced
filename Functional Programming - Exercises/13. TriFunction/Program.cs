using System;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {

                if (func(name, n))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
            
            
        }
        public static bool func(string name, int n)
        {
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                count += name[i];
            }
            return count >= n;
        }
    }
}
