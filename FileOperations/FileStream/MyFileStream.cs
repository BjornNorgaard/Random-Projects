using System;
using System.IO;

namespace FileStream
{
    public class MyFileStream
    {
        private System.IO.FileStream _fs = new System.IO.FileStream("filename.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

        public void CreateFile()
        {
            // put something in the file, and make it
            for (int i = 0; i < 20; i++)
            {
                _fs.WriteByte((byte)i);
            }

            // read from the file
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0} ", _fs.ReadByte()); // Not L10N
            }

            // close the stream, for some reason...
            _fs.Close();
        }

        public void DeleteFile()
        {

        }
    }
}
