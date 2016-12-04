namespace Procalender.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new PShopClient();
            var result = client.UploadAnswer();
        }
    }
}
