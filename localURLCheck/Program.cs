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

    class Ollie
    {
        // my method takes all of the html on the website and checks to see if it contains the local IP address
        public static void Contain()
        {
            HtmlAgilityPack.HtmlWeb website = new();
            HtmlAgilityPack.HtmlDocument document = website.Load("https://portland-fuel.co.uk/returnipaddress.php?requestip=$2y$10$IxSXcZswXCFeN7Y0tvjYmuweTvUwfBqqnkuFy.xrri1hBdeYF2C96");
            var dataList = document.DocumentNode.SelectNodes("//div").ToList();
            string ip = Convert.ToString(dataList);
            bool check = false;
            if (ip.Contains("81.143.215.110") == true)
            {
                check = true;
            }
            Console.WriteLine(check);
        }
    }

    class Steve
    {
        //test 
        public static void Array()
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://portland-fuel.co.uk/returnipaddress.php?requestip=$2y$10$IxSXcZswXCFeN7Y0tvjYmuweTvUwfBqqnkuFy.xrri1hBdeYF2C96");
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            using (StreamReader sr = new(myResponse.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                string allLines = sr.ReadToEnd();

                bool isNotLocal = true;
                string result = sr.ReadLine();
                while (!string.IsNullOrWhiteSpace(result))
                {
                    if (result.Substring(0, 6) == "\t<div>")
                    {
                        if (result.Split(',')[1] != "81.143.215.110") isNotLocal = true;
                        Console.WriteLine(result.Split(',')[1]);
                        break;
                    }
                    result = sr.ReadLine();
                }
                Console.Write(isNotLocal);
            }
        }
    }
}
