namespace UrlOpener.Interface
{
    public interface IUrlOpener
    {
        void OpenAllUrls(string[] urls, bool incognito = false);
        void OpenUrl(string url, bool incognito = false);
    }
}
