using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string data = string.Empty;
            for (int i = 0; i < n; i++)
            {
                data += Console.ReadLine();
               
            }
            List<string> numbers = new List<string>(Check(data));
            numbers = numbers.Where(x => x.Length % 3 == 0).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                string asc = string.Empty;
                for (int j = 0; j < numbers[i].Length; j += 3)
                {
                    asc += numbers[i][j];
                    asc += numbers[i][j + 1];
                    asc += numbers[i][j + 2];
                    int num = int.Parse(asc);
                    char t = (char)(num - 23);

                    Console.Write(t);

                    asc = string.Empty;
                }
            }
            //Console.WriteLine(string.Join(", ",numbers));
        }

        private static List<string> Check(string data)
        {
            List<string> result = new List<string>();
            string temp = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '{')
                {
                    List<string> asd = new List<string>();

                    int index = i;
                    while (index < data.Length && data[index] != '}' )
                    {
                        
                        if (char.IsDigit(data[index]))
                        {
                            temp += data[index];
                            if (!char.IsDigit(data[index +1]))
                            {
                                asd.Add(temp);
                                temp = string.Empty;
                            }
                        }

                        index++;
                        if (index == data.Length)
                        {
                            asd.Clear();
                            temp = string.Empty;
                            break;
                        }
                        if (data[index] == '}')
                        {
                            result.AddRange(asd);
                            asd.Clear();
                            break;
                            

                        }
                        if (data[index] == ']')
                        {
                            asd.Clear();
                            temp = string.Empty;
                            break;
                        }
                    }
                    asd.Clear();
                }
                if (data[i] == '[')
                {
                    List<string> asd = new List<string>();

                    int index = i;
                    while (index < data.Length && data[index] != '}')
                    {

                        if (char.IsDigit(data[index]))
                        {
                            temp += data[index];
                            if (index + 1  < data.Length && !char.IsDigit(data[index + 1]))
                            {
                                asd.Add(temp);
                                temp = string.Empty;
                            }
                        }

                        index++;
                        if (index == data.Length)
                        {
                            temp = string.Empty;
                            asd.Clear();
                            break;
                            
                        }
                        if (data[index] == ']')
                        {
                            result.AddRange(asd);
                            asd.Clear();
                            break;
                        }
                        if (data[index] == '}')
                        {
                            temp = string.Empty;
                            asd.Clear();
                            break;
                           
                        }
                    }
                   
                }
            }
            return result;
        }
    }
}
