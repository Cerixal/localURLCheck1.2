using System;
using System.Net;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace localURLCheck
{

    class Program
    {
        static void Main(string[] args)
        {
            // adds a stopwatch to time program for efficiency
            Stopwatch stopWatch = new();
            stopWatch.Start();
            // repeats each method 1000 times while timing it to see which one perfoms best
            for (int i = 0; i < 1000; i++)
            {
                // uses classes to keep code cleaner
                Ollie.Contain();
                Steve.Array();
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadLine();
        }
    }
}
