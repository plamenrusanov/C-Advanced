using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Breadth_first_search
{
    class Program
    {
        static void Main(string[] args)
        {
            //            начин на действие обхождане в ширина(G, v):
            //2      създаване на опашкаQ
            //3      добавяне на v в Q
            //4      отбелязваме v
            //5      докато Q не е празна:
            //6          t ← Q.dequeue()(премахване)
            //7          ако t това, което търсим:
            //8              връщаме t
            //9          за всички edges e in G.adjacentEdges(t) прави
            //10             u ← G.adjacentVertex(t, e)
            //11             ако u не е маркиран:
            //12                  маркираме u
            //13                  вмъкваме(enqueue) u в Q
            //14     връщаме none
            string path = "C:\\Users\\user\\Source\\Repos\\Calculator";
            BreadthFirstSearch(path);
        }
        public static void BreadthFirstSearch(string path)
        {
            var queue = new Queue<string>();
            queue.Enqueue(path);

            int count = 0;
            while (queue.Count != 0)
            {
                string currentDirectory = queue.Dequeue();
                string[] directories = Directory.GetDirectories(currentDirectory);
                for (int i = 0; i < directories.Length; i++)
                {
                    queue.Enqueue(directories[i]);
                }

                Console.WriteLine($"{new string('-', count)} {currentDirectory}");
               // count++;
            }

            
        }
    }
}
