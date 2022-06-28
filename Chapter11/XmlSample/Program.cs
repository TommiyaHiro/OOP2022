﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace XmlSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var wc = new WebClient()) {
                var stream = wc.OpenRead("https://news.yahoo.co.jp/rss/media/jomo/all.xml");

                var xdoc = XDocument.Load(stream);
                var xNews = xdoc.Root.Descendants("item").Select(x=>(string)x.Element("title"));

                foreach(var data in xNews) {
                    Console.WriteLine(data);

                }

            }
        }
    }
}
