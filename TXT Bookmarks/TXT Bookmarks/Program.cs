using System.Diagnostics;
using System.IO;
using static System.Console;

namespace TXT_Bookmarks
{
    internal class Program
    {
        private static string[] _filesInDirectory = { };
        private static string[] _lines = { };

        public static void OpenSitesInThisFile(int fileToOpen)
        {
            _lines = File.ReadAllLines(_filesInDirectory[fileToOpen]);
            foreach (var line in _lines)
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
            var linesInFile = File.ReadAllLines(_filesInDirectory[fileToOpen]);

            var nameNumberForFile = 1;
            for (var i = 0; i < linesInFile.Length; i++)
            {
                using (var writer = new StreamWriter("file" + nameNumberForFile + ".txt"))
                {
                    for (var j = 0; j < linesInFile.Length / numberOfFilesToSplitInto; j++)
                    {
                        writer.Write(linesInFile[i] + "\n");
                        if (j != linesInFile.Length / numberOfFilesToSplitInto - 1)
                        {
                            i++;
                        }
                    }
                    writer.Close();
                    nameNumberForFile++;
                }
            }
        }

        private static void PrintFilesInCurrentFolder()
        {
            _filesInDirectory = Directory.GetFiles(Directory.GetCurrentDirectory());

            for (var i = 0; i < _filesInDirectory.Length; i++)
            {
                _filesInDirectory[i] = Path.GetFileName(_filesInDirectory[i]);
            }

            for (var i = 0; i < _filesInDirectory.Length; i++)
            {
                var file = _filesInDirectory[i];
                WriteLine("\t" + "(" + i + ") " + file);
            }
        }

        private static void Main()
        {
            WriteLine("What do u want to do?" +
                              "\n\t (1) Open all sites in a file." +
                              "\n\t (2) Split a file into smaller filesInDirectory.");
            Write("\nChoice: ");

            var choice = ReadLine();
            Clear();

            if (choice != null && int.Parse(choice) == 1)
            {
                WriteLine("You can open one of these filesInDirectory:");
                PrintFilesInCurrentFolder();
                Write("\nChoice: ");
                var numberOfFileToOpen = int.Parse(ReadLine());
                OpenSitesInThisFile(numberOfFileToOpen);
            }
            else if (choice != null && int.Parse(choice) == 2)
            {
                WriteLine("You can split one of these filesInDirectory:");
                PrintFilesInCurrentFolder();
                Write("\nChoice: ");
                var file = int.Parse(ReadLine());
                Write("How many file should it be split into: ");
                Write("\nChoice: ");
                var numberOfFileToSplitItInto = int.Parse(ReadLine());
                SplitFileIntoSmallerFiles(file, numberOfFileToSplitItInto);
            }
        }
    }
}
