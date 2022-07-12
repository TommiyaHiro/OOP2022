﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static Exercise01.Employee;

namespace Exercise01 {
    [XmlRoot("employee")]
    public class Employee {
        [XmlElement(ElementName = "title")]
        public int Id { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "hiradate")]
        public DateTime HireDate { get; set; }
        public override string ToString() {
            return string.Format("[Id={0}, Name={1}, HireDate={2}]",
                                  Id, Name, HireDate);
        }

        //1-4で使用する
        [DataContract(Name = "employee2")]
        public class Employee2 {
            public int Id { get; set; }
            [DataMember(Name = "name")]
            public string Name { get; set; }
            [DataMember(Name = "hireDate")]
            public DateTime HireDate { get; set; }
        }


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

                using(var writer = XmlWriter.Create(outfile)) {
                    var serializer = new XmlSerializer(emp.GetType());
                    serializer.Serialize(writer, emp);
                }

                using(var reader = XmlReader.Create(outfile)) {
                    var serializer = new XmlSerializer(typeof(Employee));
                    var employee = serializer.Deserialize(reader) as Employee;
                    //確認用
                    Console.WriteLine(employee);
                }
            }


            private static void Exercise1_2(string v) {
                var emps = new Employee[] {
                new Employee {
                    Id = 123,
                    Name = "出井 秀行",
                    HireDate = new DateTime(2001, 5, 10)
                },
                new Employee {
                    Id = 139,
                    Name = "大橋 孝仁",
                    HireDate = new DateTime(2004, 12, 1)
                },
            };

                var settings = new XmlWriterSettings {
                    Encoding = new System.Text.UTF8Encoding(false),
                    Indent = true,
                    IndentChars = "  ",
                };

                using(var writer = XmlWriter.Create(v, settings)) {
                    var serializer = new DataContractSerializer(emps.GetType());
                    serializer.WriteObject(writer, emps);
                }
            }

            private static void Exercise1_3(string v) {
                using(var reader = XmlReader.Create(v)) {
                    var serializer = new DataContractSerializer(typeof(Employee[]));
                    var employees = serializer.ReadObject(reader) as Employee[];
                    //Console.WriteLine(novel);
                    foreach(var employee in employees) {
                        Console.WriteLine(employee);
                    }
                }

            }

            private static void Exercise1_4(string v) {
            var emps = new Employee2[] {
                new Employee2 {
                    Id = 123,
                    Name = "出井 秀行",
                    HireDate = new DateTime(2001, 5, 10)
                },
                new Employee2 {
                    Id = 139,
                    Name = "大橋 孝仁",
                    HireDate = new DateTime(2004, 12, 1)
                },
            };

            var settings = new DataContractJsonSerializerSettings {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd")
            };


            //シリアル化
            using(var stream = new FileStream(v, FileMode.Create,
                                                      FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(emps.GetType(), settings);
                //var serializer = new DataContractJsonSerializer(emps.GetType(),new DataContractJsonSerializerSettings
                //{
                //    DateTimeFormat = new DateTimeFormat("yyyy-MM-dd")
                //});
                serializer.WriteObject(stream, emps);
            }
        }
    }
}

