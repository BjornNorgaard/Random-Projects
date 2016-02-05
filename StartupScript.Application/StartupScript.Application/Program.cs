using System.Collections.Generic;
using System.Diagnostics;

namespace StartupScript.Application
{
    class Program
    {
        private static readonly List<string> WebsiteList = new List<string>
        {
            "google.com",
            "youtube.com",
            "boredpanda.com",
            "teksyndicate.com"
        };

        static void Main(string[] args)
        {
            foreach (string site in WebsiteList)
            {
                //Process.Start("chrome.exe", "--incognito " + "www." + site);
                Process.Start("www." + site);
            }
        }
    }
}
