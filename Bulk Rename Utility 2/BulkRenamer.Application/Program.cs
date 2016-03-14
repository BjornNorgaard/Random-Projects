using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRenamer.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Norgaard\Downloads";

            Console.WriteLine("Reneming all files in:\n" + path);

            string[] files = System.IO.Directory.GetFiles(path);

            Console.WriteLine("\nThe files are currently named:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
