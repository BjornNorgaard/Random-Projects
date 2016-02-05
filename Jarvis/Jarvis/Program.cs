using System;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;

namespace Jarvis
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak("Welcome to the speaking performance monitor!");

            #region Performance Counters
            PerformanceCounter performanceCounter_CPU = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            PerformanceCounter performanceCounter_RAM = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            PerformanceCounter performanceCounter_TIME = new PerformanceCounter("System", "System Up Time"); 
            #endregion

            while (true)
            {
                float currentCPUPercentage = performanceCounter_CPU.NextValue();
                float currentRAMPercentage = performanceCounter_RAM.NextValue();

                Console.WriteLine("CPU Load:  {0}%", currentCPUPercentage);
                Console.WriteLine("RAM Usage: {0}%", currentRAMPercentage);

                string cpuLoadVocalMessage = String.Format("The current CPU load  is: {0}", currentCPUPercentage);
                string ramLoadVocalMessage = String.Format("The current RAM usage is: {0}", currentRAMPercentage);

                Thread.Sleep(500);
            }
        }
    }
}
