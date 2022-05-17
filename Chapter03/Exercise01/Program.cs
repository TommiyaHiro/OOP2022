﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {

        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            Exercise1_1(numbers);
            Console.WriteLine("----");

            Exercise1_2(numbers);
            Console.WriteLine("----");

            Exercise1_3(numbers);
            Console.WriteLine("----");

            Exercise1_4(numbers);


        }

        private static void Exercise1_1(List<int> numbers) {
            var exist = numbers.Exists(n => n % 8 == 0 && n % 9 == 0);
            if(exist)
                Console.WriteLine("存在しています");
            else
                Console.WriteLine("存在していません");
        }

        private static void Exercise1_2(List<int> numbers) {
            numbers.ForEach(n => Console.WriteLine(n / 2.0));
        }

        private static void Exercise1_3(List<int> numbers) {
            foreach(var n in numbers.Where(n => n >= 50)) {
                Console.WriteLine(n);
            }
            //var num = numbers.Where(n => n >= 50);
            //foreach(var n in num) {
            //    Console.WriteLine(n);
            //}
        }

        private static void Exercise1_4(List<int> numbers) {
            var list = numbers.Select(n => n * 2).ToArray();
            numbers[5] = 5000;
            foreach(var n in list) {
                Console.WriteLine(n);
            }
        }

    }
}
