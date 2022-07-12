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

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var novelist = Exercise2_1("sample.xml");
            Exercise2_2(novelist, "novelist.json");

            // これは確認のためのコード 12.2.1
            Console.WriteLine("{0} {1}", novelist.Name, novelist.Birth);
            foreach(var title in novelist.Masterpieces) {
                Console.WriteLine(title);
            }
            Console.WriteLine();

            // これは確認のためのコード 12.2.2
            Console.WriteLine(File.ReadAllText("novelist.json"));
            Console.WriteLine();
        }

        private static Novelist Exercise2_1(string file) {
            //引数で受け取ったファイルを逆シリアル化しNovelistクラスのオブジェクトにセットする
            using(var reader = XmlReader.Create(file)) {
                var serializer = new XmlSerializer(typeof(Novelist));
                var nevelist = serializer.Deserialize(reader) as Novelist;

                //Novelistクラスのオブジェクトを返却
                return nevelist;
            }
        }

        private static void Exercise2_2(Novelist novelist, string outfile) {
            using(var stream = new FileStream(outfile, FileMode.Create,
                                                FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(novelist.GetType(),
                                                        new DataContractJsonSerializerSettings {
                                                            DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ssZ")
                                                        });
                serializer.WriteObject(stream, novelist);
            }
        }
    }
}
