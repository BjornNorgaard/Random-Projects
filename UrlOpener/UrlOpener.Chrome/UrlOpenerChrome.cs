using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using UrlOpener.Interface;

namespace UrlOpener.Chrome
{
    public class UrlOpenerChrome : IUrlOpener
    {
        public void OpenAllUrls(string[] urls, bool incognito = false)
        {
            foreach (var url in urls)
            {
                OpenUrl(url, incognito);
                Thread.Sleep(10);
            }
        }

        public void OpenUrl(string url, bool incognito)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    var newline = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", "/c start chrome " + (incognito ? "--incognito" : "") + " " + newline));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
