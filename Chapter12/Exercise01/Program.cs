﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    public class Employee {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
    }

    class Program {
        static void Main(string[] args) {
            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            //Console.WriteLine(File.ReadAllText("employees.json"));
        }

        private static void Exercise1_1(string outfile) {
            var emp = new Employee {
                Id = 123,
                Name = "出井　秀行",
                HireDate = new DateTime(2001, 5, 10)
            };

            using(var writer = XmlWriter.Create("employee.xml")) {
                var serializer = new XmlSerializer(emp.GetType());
                serializer.Serialize(writer, emp);
            }

            Display("employee.xml");

            using(var reader = XmlReader.Create("novels.xml")) {
                var serializer = new XmlSerializer(typeof(Employee));
                var novels = serializer.Deserialize(reader) as Employee;
            }
        }

        private static void Display(string v) {
            var lines = File.ReadLines(v                                                                       );
            foreach(var line in lines)
                Console.WriteLine(line);
        }

        private static void Exercise1_2(string v) {

        }

        private static void Exercise1_3(string v) {
        }

        private static void Exercise1_4(string v) {
        }
    }
}
