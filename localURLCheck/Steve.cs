using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace localURLCheck
{
    class Steve
    {
        public static void Array()
        {
            // uses System.Net HttpWebRequest to navigate to the web page 
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://portland-fuel.co.uk/returnipaddress.php?requestip=$2y$10$IxSXcZswXCFeN7Y0tvjYmuweTvUwfBqqnkuFy.xrri1hBdeYF2C96");
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            using (StreamReader sr = new(myResponse.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                // reads all of the html on the page and saves it to a variable called allLines
                string allLines = sr.ReadToEnd();
                bool isNotLocal = true;
                string result = sr.ReadLine();
                // makes sure there is content to account for internet issues
                while (!string.IsNullOrWhiteSpace(result))
                {
                    if (result.Substring(0, 6) == "\t<div>")
                    {
                        // checks a specific part of the file to see if it is the same as the local ip address
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
