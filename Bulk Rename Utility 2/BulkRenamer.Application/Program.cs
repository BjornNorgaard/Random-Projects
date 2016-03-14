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
            Console.WriteLine("Hello world!");
            //System.IO.File.Create(@"C:\Users\Norgaard\Downloads\Hello.txt");

            //System.IO.File.Move(@"C:\Users\Norgaard\Downloads\Hello.txt", @"C:\Users\Norgaard\Downloads\Derp.txt");

            
            Console.WriteLine("" + Directory.GetCurrentDirectory());
        }
    }
}
