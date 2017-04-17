using System;

namespace AsyncAwaitDemo.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var myClass = new AwaitingClass();
        }
    }
}
