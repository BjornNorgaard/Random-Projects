using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    public class AwaitingClass
    {
        public AwaitingClass()
        {
            Go();
        }

        private void Go()
        {
            GoAsync();

            var number = 0;
            while (true)
            {
                Console.WriteLine($"{nameof(Go)} {number++}s has passed...");
                Thread.Sleep(1000);
            }
        }

        private async void GoAsync()
        {
            Console.WriteLine($"Method {nameof(GoAsync)} has started!");

            IEnumerable<Task<int>> tasks = new List<Task<int>>
            {
                Sleep(3000),
                Sleep(2000),
                Sleep(1000),
                Sleep(4000),
                Sleep(6000),
                Sleep(7000),
                Sleep(5000)
            };

            int[] results = await Task.WhenAll(tasks);

            Console.WriteLine($"Method {nameof(GoAsync)} slept for a total of {results.Sum()} ms.");
        }

        private async Task<int> Sleep(int ms)
        {
            //Console.WriteLine($"Sleeping for {ms} at {Environment.TickCount}");
            await Task.Delay(ms);
            //Console.WriteLine($"Sleeping for {ms} finished at {Environment.TickCount}");
            return ms;
        }
    }
}
