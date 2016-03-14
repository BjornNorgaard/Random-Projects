using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Rename_Utility_2
{
    public class Brutto
    {
        #region Properties

        private string[] _files = { "empty" };
        private string _folder = "empty";
        private string _newName = "empty";

        public string Folder
        {
            get { return _folder; }
            set { _folder = value; }
        }

        private string[] Files
        {
            get { return _files; }
            set { _files = value; }
        }

        public string NewName
        {
            get { return _newName; }
            set { _newName = value; }
        }

        #endregion

        #region Methods

        private void RenameFile(string oldFilename, string newFilename)
        {
            File.Move(oldFilename, newFilename);
        }

        public void RenameAllFilesInFolder()
        {
            // Load filenames into stringarray
            Files = Directory.GetFiles(_folder);

            // Renaming of files to choosen convention
            for (int i = 0; i < Files.Length; i++)
            {
                RenameFile(Files[i], _newName + (i + 1));
            }
        }

        #endregion

    }
}
