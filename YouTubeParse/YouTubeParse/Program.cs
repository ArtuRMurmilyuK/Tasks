using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using Leaf.xNet;
using Fizzler;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using HtmlDoc = HtmlAgilityPack.HtmlDocument;

namespace YouTubeParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parse parse = new Parse();
            parse.InitHttp();
        }
    }

    public class Parse
    {
        public void InitHttp()
        {
            var httpReq = new HttpRequest();

            string response = httpReq.Get(Console.ReadLine()).ToString();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            var html = new HtmlDocument();
            var document = html.DocumentNode;
            var innerHtml = document.QuerySelector(".title").InnerHtml;
            Console.WriteLine(innerHtml);

            File.WriteAllText("test.html", response, Encoding.UTF8);
            Process.Start("test.html");
            Console.ReadKey();
        }

    }
}
