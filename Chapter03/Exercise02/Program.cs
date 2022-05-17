﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
               "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Exercise2_1(names);
            Console.WriteLine();

            Exercise2_2(names);
            Console.WriteLine();

            Exercise2_3(names);
            Console.WriteLine();

            Exercise2_4(names);
            Console.WriteLine();

        }

        private static void Exercise2_4(List<string> names) {
            throw new NotImplementedException();
        }

        private static void Exercise2_3(List<string> names) {
            throw new NotImplementedException();
        }

        private static void Exercise2_2(List<string> names) {
            throw new NotImplementedException();
        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了");
            do {
                var line = Console.ReadLine(); // 入力読み込み
                if(string.IsNullOrEmpty(line))
                    break;
                int index = names.FindIndex(n => n == line);
                Console.WriteLine(index);
            } while(true);

        }
    }
}
