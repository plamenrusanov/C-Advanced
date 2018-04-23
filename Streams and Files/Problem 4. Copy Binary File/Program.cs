using System.IO;

namespace Problem_4._Copy_Binary_File
{
    class Program
    {
        static void Main()
        {
            using (FileStream reader = new FileStream("..\\Resources\\copyMe.png", FileMode.Open))
            {
                using(FileStream writer = new FileStream(".\\result.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (reader.Read(buffer, 0, buffer.Length) != 0)
                    {
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
               
            }
            
        }
    }
}
