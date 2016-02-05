using System;
using System.Threading;
using FileStream;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFileStream myFileStream = new MyFileStream();
            myFileStream.CreateFile();

            Thread.Sleep(5000);



            Console.WriteLine();
        }
    }
}
