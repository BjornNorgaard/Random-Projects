using System;
using System.Diagnostics;
using System.IO;

namespace TXT_Bookmarks
{
    class Program
    {
        public static void OpenSitesInThisFile(string file)
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            //Debug.WriteLine("File contains these sites:");

            foreach (var line in lines)
            {
                if (line.Contains("http"))
                {
                    Debug.WriteLine("\t" + line);
                    Process.Start("chrome.exe", "--incognito " + line);
                }
            }
        }

        public static void SplitFileIntoSmallerFiles(string file, int numberOfFilesToSplitInto)
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            int nameNumberForFile = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                using (StreamWriter sw = new StreamWriter("file" + nameNumberForFile + ".txt"))
                {
                    for (int j = 0; j < lines.Length / numberOfFilesToSplitInto; j++)
                    {
                        sw.Write(lines[i] + "\n");
                        if (j != lines.Length / numberOfFilesToSplitInto - 1)
                        {
                            i++;
                        }
                    }
                    sw.Close();
                    nameNumberForFile++;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("What do u want to do?" +
                              "\n\t (1) Open all sites in a file." +
                              "\n\t (2) Spit a file into smaller files.");
            Console.Write("Choice: ");

            var choice = Console.ReadLine();

            if (choice != null && int.Parse(choice) == 1)
            {
                Console.Write("\t Open all sites in this file: ");
                string file = Console.ReadLine();

                OpenSitesInThisFile(file);
            }
            else if (choice != null && int.Parse(choice) == 2)
            {
                Console.Write("\t Which file do you want to split: ");
                string file = Console.ReadLine();

                Console.Write("\t How many file should it be split into: ");
                int numberOfFileToSplitItInto = int.Parse(Console.ReadLine());

                SplitFileIntoSmallerFiles(file, numberOfFileToSplitItInto);
            }

            //SplitFileIntoSmallerFiles("readthis.txt", 3); // for testing

        }
    }
}
