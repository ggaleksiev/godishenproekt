using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace godishenproekt
{
    public static class LibraryMenu
    {
        public static void AddBook(Library library)
        {
            Console.WriteLine("Добавяне на книга");

            Console.Write("Заглавие: ");
            string title = Console.ReadLine();

            Console.Write("Автор: ");
            string author = Console.ReadLine();

            Console.Write("Жанр: ");
            string genre = Console.ReadLine();

            Console.Write("Година на издаване: ");
            string year = Console.ReadLine();

            Console.Write("Брой страници: ");
            string pageCount = Console.ReadLine();

            Book book = new Book(title, author, genre, year, pageCount);
            library.AddBook(book);
        }
        public static void RemoveBook(Library library)
        {
            Console.WriteLine("Премахване на книга");

            Console.WriteLine("Загавие на книгата: ");
            string title = Console.ReadLine();

            library.RemoveBook(title);
        }

        public static void SearchByAuthor(Library library)
        {
            Console.WriteLine("Търсене на книга по автор");

            Console.Write("Въведете име на автор: ");
            string author = Console.ReadLine();

            library.SearchByAuthor(author);
        }

        public static void SearchByTitle(Library library)
        {
            Console.WriteLine("Търсене на книга по заглавие");

            Console.Write("Въведете заглавие на книга: ");
            string title = Console.ReadLine();

            library.SearchByTitle(title);
        }
        public static void SearchByYear(Library library)
        {
            Console.WriteLine("Търсене на книга според година на издаване");

            Console.WriteLine("Въведете годината на издаване: ");
            string year = Console.ReadLine();

            library.SearchByYear(year);
        }
        public static void SearchByPageCount(Library libraly)
        {
            Console.WriteLine("Търсене на книга според броя страници");

            Console.WriteLine("Въведете броя страници: ");
            string pageCount = Console.ReadLine();

            libraly.SearchByPageCount(pageCount);
        }
        public static void GetAllBooks(Library library)
        {
            library.DisplayAllBooks();
        }
    }

}