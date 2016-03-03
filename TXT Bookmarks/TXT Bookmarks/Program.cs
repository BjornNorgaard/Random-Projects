using System;
using System.Diagnostics;
using System.IO;

namespace TXT_Bookmarks
{
    class Program
    {
        static string[] files = { };
        static string[] lines = { };

        public static void OpenSitesInThisFile(int fileToOpen)
        {
            lines = System.IO.File.ReadAllLines(files[fileToOpen]);

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

        public static void SplitFileIntoSmallerFiles(int fileToOpen, int numberOfFilesToSplitInto)
        {
            string[] lines = System.IO.File.ReadAllLines(files[fileToOpen]);

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

        private static void PrintFilesInCurrentFolder()
        {
            files = System.IO.Directory.GetFiles(Directory.GetCurrentDirectory());

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }

            //Console.WriteLine("\n");
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                Console.WriteLine("\t" + "(" + i + ") " + file);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("What do u want to do?" +
                              "\n\t (1) Open all sites in a file." +
                              "\n\t (2) Spit a file into smaller files.");
            Console.Write("Choice: ");

            var choice = Console.ReadLine();
            Console.Clear();

            if (choice != null && int.Parse(choice) == 1)
            {
                Console.WriteLine("You can open one of these files:");

                PrintFilesInCurrentFolder();

                Console.Write("Choice: ");
                //Console.Write("\nOpen all sites in this file: ");
                int numberOfFileToOpen = int.Parse(Console.ReadLine());

                OpenSitesInThisFile(numberOfFileToOpen);
            }
            else if (choice != null && int.Parse(choice) == 2)
            {
                Console.WriteLine("You can split one of these files:");
                PrintFilesInCurrentFolder();

                Console.Write("Choice: ");
                int file = int.Parse(Console.ReadLine());

                Console.Write("How many file should it be split into: ");
                Console.Write("\nChoice: ");
                int numberOfFileToSplitItInto = int.Parse(Console.ReadLine());
                
                SplitFileIntoSmallerFiles(file, numberOfFileToSplitItInto);
            }

            //SplitFileIntoSmallerFiles("readthis.txt", 3); // for testing

        }
    }
}
