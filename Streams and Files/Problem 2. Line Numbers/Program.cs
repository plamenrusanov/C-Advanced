using System.IO;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main()
        {
            using (StreamReader streamReader = new StreamReader("..\\Resources\\text.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter(".\\textNew.txt"))
                {
                    string line;
                    int count = 1;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine($"Line {count}: {line}");
                        count++;
                    }
                }

            }
        }
    }
}
