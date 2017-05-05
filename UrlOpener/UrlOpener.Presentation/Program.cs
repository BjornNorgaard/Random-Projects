using System.IO;
using UrlOpener.Chrome;
using UrlOpener.Interface;

namespace UrlOpener.Presentation
{
    class Program
    {
        static void Main()
        {
            var lines = File.ReadAllLines("quicklaunchsites.txt");

            IUrlOpener opener = new UrlOpenerChrome();
            opener.OpenAllUrls(lines, true);
        }
    }
}
