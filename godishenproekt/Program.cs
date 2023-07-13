using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace godishenproekt
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Library library = new Library();

            library.DisplayAllBooks();

            bool isRunning = true;

            while (isRunning)
            {
                // Console.Clear();
                Console.WriteLine("\n\nМЕНЮ:");
                Console.WriteLine("1. Добавяне на книга");
                Console.WriteLine("2. Премахване на книга");
                Console.WriteLine("3. Търсене на книга по автор");
                Console.WriteLine("4. Търсене на книга по заглавие");
                Console.WriteLine("5. Търсене на книга по година на издаване");
                Console.WriteLine("6. Търсене на книга по брой страници");
                Console.WriteLine("7. Отпечатай всички налични книги");
                Console.WriteLine("0. Изход");

                Console.Write("Изберете опция (въведете номер): ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        LibraryMenu.AddBook(library);
                        break;
                    case "2":
                        LibraryMenu.RemoveBook(library);
                        break;
                    case "3":
                        LibraryMenu.SearchByAuthor(library);
                        break;
                    case "4":
                        LibraryMenu.SearchByTitle(library);
                        break;
                    case "5":
                        LibraryMenu.SearchByYear(library);
                        break;
                    case "6":
                        LibraryMenu.SearchByPageCount(library);
                        break;
                    case "7":
                        LibraryMenu.GetAllBooks(library);
                        break;
                    case "0":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Невалиден избор. Моля, опитайте отново.");
                        break;
                }
                // Console.ReadKey();

                Console.WriteLine();
            }
            // Запазване на книгите във файл
            library.SaveBooksToFile(@"../../../books.txt");
        }
    }
}