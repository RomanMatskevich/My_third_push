using System;

using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace ConsoleApp11
{
    class Program
    {
        


        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string line = wc.DownloadString("https://www.gismeteo.ua/ua/weather-zhytomyr-4943/now/");
            Console.WriteLine(line);

            //
            Regex reg = new Regex(@" < span class=""js_value tab-weather__value_l"">""\s\+[0 - 9]+""");
            string Temperature;
            Regex regTemp = new Regex(@"<span class=""js_value tab-weather__value_l"">\+[0-9]+<span class=""tab - weather__value_m"">");
            Match m = regTemp.Match(line);
            Temperature = m.Groups[1].Value;
            Console.WriteLine(Temperature);


        }
    }
}
