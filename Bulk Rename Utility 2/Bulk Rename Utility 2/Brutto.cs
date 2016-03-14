using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Rename_Utility_2
{
    public class Brutto
    {
        public void RenameFile(string oldFilename, string newFilename)
        {
            System.IO.File.Move(oldFilename, newFilename);
        }

        public void RenameAllFilesInFolder(string folder)
        {
            // Load filenames into stringarray
            string[] files = System.IO.Directory.GetFiles(folder);

            for (int i = 0; i < files.Length; i++)
            {
                RenameFile(files[i], "derpfile" + i);
            }
        }
    }
}
