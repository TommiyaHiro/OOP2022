using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books
                .Max(b => b.Price);
            var book = Library.Books
                .First(b => b.Price == max);
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
        }

        private static void Exercise1_4() {
            var books = Library.Books
                .Join(Library.Categories,
                book => book.CategoryId,
                category => category.Id,
                (book, category) => new {
                    Title = book.Title,
                    Category = category.Name,
                    PublishedYear = book.PublishedYear,
                    Price = book.Price
                }
                );
            foreach(var book in books
                .OrderByDescending(x => x.PublishedYear)
                .ThenByDescending(x => x.Price)) {

                Console.WriteLine($"{book.PublishedYear}年,{book.Price}円,{book.Title},({book.Category})");
            }
        }

        private static void Exercise1_5() {
        }

        private static void Exercise1_6() {
        }

        private static void Exercise1_7() {
        }

        private static void Exercise1_8() {
        }
    }
}
