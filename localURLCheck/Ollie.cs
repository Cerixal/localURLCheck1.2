using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace localURLCheck
{
    class Ollie
    {
        // my method takes all of the html on the website and checks to see if it contains the local IP address
        public static void Contain()
        {
            HtmlAgilityPack.HtmlWeb website = new();
            HtmlAgilityPack.HtmlDocument document = website.Load("https://portland-fuel.co.uk/returnipaddress.php?requestip=$2y$10$IxSXcZswXCFeN7Y0tvjYmuweTvUwfBqqnkuFy.xrri1hBdeYF2C96");
            // takes all of the HTML and turns it into a list
            var dataList = document.DocumentNode.SelectNodes("//div").ToList();
            string ip = Convert.ToString(dataList);
            bool check = false;
            // checks all of the content pulled for the ip address.
            if (ip.Contains("81.143.215.110") == true)
            {
                check = true;
            }
            Console.WriteLine(check);
        }
    }
}
