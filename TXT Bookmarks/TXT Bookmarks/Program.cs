using System;
using System.Diagnostics;

namespace TXT_Bookmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("readthis.txt");
          
            Debug.WriteLine("File contains these sites:");

            foreach (var line in lines)
            {
                if (line.Contains("http"))
                {
                    Debug.WriteLine("\t" + line);
                    Process.Start("chrome.exe", "--incognito " + line.ToString());
                }
            }
        }
    }
}
