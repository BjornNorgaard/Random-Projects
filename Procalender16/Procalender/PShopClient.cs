using System;
using System.Net.Http;

namespace Procalender
{
    public class PShopClient
    {
        public static HttpClient Client { get; set; }

        public PShopClient()
        {
            // http://jul.proshop.dk/Home/SubmitQuestion?Length=4
            Client.BaseAddress = new Uri("http://jul.proshop.dk/Home/SubmitQuestion?Length=4");
        }

        public bool PostAll()
        {
            try
            {
            }
            catch (Exception e)
            {
                throw new Exception($"Hello, this went wrong: {e}");
            }

            return false;
        }
    }
}
