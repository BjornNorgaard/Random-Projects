using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Procalender
{
    public class PShopClient
    {
        public static HttpClient Client { get; set; } = new HttpClient();

        public PShopClient()
        {
            // http://jul.proshop.dk/Home/SubmitQuestion?Length=4
            Client.BaseAddress = new Uri("http://jul.proshop.dk/Home/");

            var listOfData = GetData();

            foreach (var formData in listOfData)
            {
                var result = UploadAnswer(formData);
            }
        }

        private List<FormData> GetData()
        {
            var listOfData = new List<FormData>();

            // TODO read data from file...

            // TODO created FormData objects
            var data = new FormData()
            {
                Address = "addressone",
                AnswerDay = DateTime.Now,
                AnswerOnQuestion = "1",
                City = "cityederp",
                Email = "oij@oi.dk",
                Name = "derphonn",
                ZipCode = "8829",
            };

            // TODO add FormData objects to list
            listOfData.Add(data);

            return listOfData;
        }

        private bool UploadAnswer(FormData data)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Email",data.Email),
                new KeyValuePair<string, string>("Navn",data.Name),
                new KeyValuePair<string, string>("Address",data.Address),
                new KeyValuePair<string, string>("ZipCode",data.ZipCode),
                new KeyValuePair<string, string>("City",data.City),
            });

            try
            {
                var responseMessage = Client.PostAsync("SubmitQuestion?Length=4", formContent);
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
