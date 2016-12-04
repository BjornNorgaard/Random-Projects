using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Procalender
{
    public class PShopClient
    {
        public static HttpClient Client { get; set; } = new HttpClient();

        public PShopClient()
        {
            // http://jul.proshop.dk/Home/SubmitQuestion?Length=4
            Client.BaseAddress = new Uri("http://jul.proshop.dk/Home/");
        }

        public bool UploadAnswer()
        {
            var data = new FormData()
            {
                Address =  "addressone",
                AnswerDay = DateTime.Now,
                AnswerOnQuestion = "1",
                City = "cityederp",
                Email = "oij@oi.dk",
                Name = "derphonn",
                ZipCode = "8829",
            };

            var settings = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateFormatString = "dd-MM-yyyy HH:mm:ss",
            };

            try
            {
                var jsonData = JsonConvert.SerializeObject(data, settings);
                var buffer = Encoding.UTF8.GetBytes(jsonData);
                var byteArrayContent = new ByteArrayContent(buffer);
                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var responseMessage = Client.PostAsync("SubmitQuestion?Length=4", byteArrayContent);
                responseMessage.Wait();
                var response = responseMessage.Result;

                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw new Exception($"Hello, this went wrong: {e}");
            }
        }
    }
}
