using System;
using System.Collections.Generic;
using System.IO;

namespace Bulk_Rename_Utility_2
{
    public class Brutto
    {
        public string NewNameForFile { get; set; }
        public string Folder { get; set; }
        public string StringContainedInTarget { get; set; }

        public void Rename()
        {
            // load files
            string[] files = Directory.GetFiles(Folder);
            List<string> ListOfFiles = new List<string>();

            foreach (string file in files)
            {
                if (file.Contains(StringContainedInTarget))
                {
                    ListOfFiles.Add(file);
                }
            }

            // get files currect extension
            string extension = Path.GetExtension(ListOfFiles[0]);
            //Console.WriteLine(extension); // For debugging

            // rename files
            for (int i = 0; i < ListOfFiles.Count; i++)
            {
                //File.Move(ListOfFiles[i], NewNameForFile + (i + 1) + extension);
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(ListOfFiles[i], NewNameForFile + (i+1) + extension);
            }
        }
    }
}
