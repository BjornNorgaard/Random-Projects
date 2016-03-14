using System;
using System.IO;
using Bulk_Rename_Utility_2;

namespace BulkRenamer.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Norgaard\Downloads";

            Console.WriteLine("Renaming all files in:\n" + path);

            string[] files = System.IO.Directory.GetFiles(path);

            Console.WriteLine("\nThe files are currently named:");
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }

            foreach (string file in files)
            {
                Console.WriteLine("\t" + file);
            }

            // do renaming bit...

            Brutto brutto = new Brutto();
            brutto.Folder = path;
            brutto.NewNameForFile = "oij";
            brutto.StringContainedInTarget = "Copy";

            brutto.Rename();
        }
    }
}
