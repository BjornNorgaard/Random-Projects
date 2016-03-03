using System;
using System.Threading;

namespace FolderOperations
{
    class Program
    {
        public static void EncryptFile(string pathToFile)
        {
            System.IO.File.Encrypt(path: pathToFile);
        }

        public static void DecryptFile(string pathToFile)
        {
            System.IO.File.Decrypt(path: pathToFile);
        }

        static void Main(string[] args)
        {
            EncryptFile("file.txt");
            Console.WriteLine("done encrypting");

            Console.WriteLine("waiting a bit...");
            Thread.Sleep(5000);

            Console.WriteLine("beginning decryption");
            DecryptFile("file.txt");
        }
    }
}
