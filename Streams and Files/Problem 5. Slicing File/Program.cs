using System;
using System.Collections.Generic;
using System.IO;

namespace Problem_5._Slicing_File
{
    class Program
    {
        static void Main()
        {
            
            Slice("..\\Resources\\sliceMe.mp4", ".\\Result\\", 5);
            var files = new List<string>
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };

            Assemble(files, ".\\AssembleFile");
        }
        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));
                long partSize = (long)Math.Ceiling((double)reader.Length / parts);
                byte[] buffer = new byte[4096];
                for (int i = 0; i < parts; i++)
                {
                    long length = 0;
                    string currentPath = destinationDirectory + $"Part-{i}{extension}";
                    using (FileStream writer = new FileStream(currentPath, FileMode.Create))
                    {
                        while (reader.Read(buffer, 0, buffer.Length) != 0)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                            length += buffer.Length;
                            if (length >= partSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.'));
            string assemblePath = $"{destinationDirectory}\\Assemble{extension}";

            using (FileStream writer = new FileStream(assemblePath, FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(".\\Result\\" + file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, buffer.Length) != 0)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
