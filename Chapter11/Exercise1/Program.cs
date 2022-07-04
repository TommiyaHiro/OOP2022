using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);
        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements().Select(x => new {
                SportsName = (string)x.Element("name"),
                TeamMember = (int)x.Element("teammembers")

            });
            foreach(var Sports in sports) {
                Console.WriteLine("{0} {1} ", Sports.SportsName, Sports.TeamMember);

            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements().Select(x => new {
                                 FirstPlay = x.Element("firstplayed").Value,
                                 KanjiName = x.Element("name").Attribute("kanji").Value})
                .OrderBy(x => int.Parse(x.FirstPlay));
            foreach(var sport in sports) {
                Console.WriteLine("{0}　{1}", sport.KanjiName,sport.FirstPlay);
            }

        }

        private static void Exercise1_3(string file) {
        }

        private static void Exercise1_4(string file, string newfile) {
        }
    }
}
