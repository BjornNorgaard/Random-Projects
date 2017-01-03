using System;
using System.Threading;
using Microsoft.Win32;

namespace RunAtStartup
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeStartup();
        }

        private static void ChangeStartup()
        {
            Console.WriteLine("Set to startup with windows? (y/n)");

            var consoleKey = Console.ReadKey(true).Key;
            do
            {
                consoleKey = Console.ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("Adding program to startup...");
                        Thread.Sleep(500);
                        Console.WriteLine("Program added!");
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Removing program from startup...");
                        Thread.Sleep(500);
                        Console.WriteLine("Program has been removed from startup!");
                        break;
                }
            } while (consoleKey != ConsoleKey.Escape);
        }

        private void Startup(bool add)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(
                       @"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (add)
            {
                key.SetValue("Tray minimizer", "\"" + System.Reflection.Assembly.GetEntryAssembly().Location + "\"");
            }
            else
            {
                key.DeleteValue("Tray minimizer");
            }

            key.Close();
        }
    }
}
