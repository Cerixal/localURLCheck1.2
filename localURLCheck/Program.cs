using System;
using System.Net;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace localURLCheck
{

    class Program
    {
        //program that checks a website to see if the returned IP address is local or not
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new();
            stopWatch.Start();

            for (int i = 0; i < 1000; i++)
            {
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
