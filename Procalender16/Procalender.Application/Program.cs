using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Procalender.Application
{
    class Program
    {
        public static HttpClient Client { get; set; } = new HttpClient();

        public static int TodaysAnswer { get; set; }

        static void Main(string[] args)
        {
            Client.BaseAddress = new Uri("http://jul.proshop.dk/Home/");

            try
            {
                Console.WriteLine("What is todays answer?");
                Console.Write("Answer: ");
                TodaysAnswer = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                TodaysAnswer = 1;
            }

            var participants = GetData();

            Console.WriteLine($"Posting with answer: {TodaysAnswer}");

            foreach (Participant participant in participants)
            {
                Console.WriteLine(UploadAnswer(participant) ? "." : " Fuck " + participant.Name);
            }

            Console.WriteLine("Done");
        }

        private static List<Participant> GetData()
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filePath = Path.Combine(userPath, @"Downloads\info.xlsx");
            Console.WriteLine(filePath);

            #region Excel setup

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            #endregion

            int rowCount = 7, colCount = 5;

            #region Excel example

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!

            //for (int rowIndex = 2; rowIndex <= rowCount; rowIndex++)
            //{
            //    for (int columnIndex = 1; columnIndex <= colCount; columnIndex++)
            //    {
            //        if (columnIndex == 1)
            //        {
            //            Console.WriteLine("\r\n");
            //        }

            //        //write the value to the console
            //        if (xlRange.Cells[rowIndex, columnIndex] != null && xlRange.Cells[rowIndex, columnIndex].Value2 != null)
            //            Console.Write(xlRange.Cells[rowIndex, columnIndex].Value2.ToString() + "\t");

            //        //add useful things here!
            //    }
            //}

            #endregion

            var paticipantData = new List<Participant>();

            for (int i = 1; i <= rowCount; i++)
            {
                var participant = new Participant()
                {
                    Email = xlRange.Cells[i, 1].Value2.ToString(),
                    Name = xlRange.Cells[i, 2].Value2.ToString(),
                    Address = xlRange.Cells[i, 3].Value2.ToString(),
                    ZipCode = xlRange.Cells[i, 4].Value2.ToString(),
                    City = xlRange.Cells[i, 5].Value2.ToString(),
                    AnswerDay = DateTime.Now,
                    AnswerOnQuestion = TodaysAnswer.ToString(),
                };

                paticipantData.Add(participant);
            }

            #region Cleanup

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            #endregion

            return paticipantData;
        }

        private static bool UploadAnswer(Participant data)
        {
#if DEBUG
            return true;
#else
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Email",data.Email),
                new KeyValuePair<string, string>("Navn",data.Name),
                new KeyValuePair<string, string>("Address",data.Address),
                new KeyValuePair<string, string>("ZipCode",data.ZipCode),
                new KeyValuePair<string, string>("City",data.City),
                new KeyValuePair<string, string>("AnswerDay",data.AnswerDay.ToString("dd-MM-yyyy hh:mm:ss")),
                new KeyValuePair<string, string>("AnswerOnQuestion",data.AnswerOnQuestion.ToString()),
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
#endif
        }
    }
}
