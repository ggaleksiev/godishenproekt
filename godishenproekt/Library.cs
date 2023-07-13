using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace godishenproekt
{
    public class Library
    {
        private List<Book> books;
        private Dictionary<string, Book> bookDictionary;

        public Library()
        {
            books = new List<Book>();
            bookDictionary = new Dictionary<string, Book>();

            LoadBooksFromFile(@"../../../books.txt");
        }
        private void LoadBooksFromFile(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] bookData = line.Split(',');

                    if (bookData.Length == 5)
                    {
                        string title = bookData[0].Trim();
                        string author = bookData[1].Trim();
                        string genre = bookData[2].Trim();
                        string year = bookData[3].Trim();
                        string pageCount = bookData[4].Trim();

                        Book book = new Book(title, author, genre, year, pageCount);
                        books.Add(book);
                        bookDictionary[title] = book;
                    }
                }

                Console.WriteLine("Книгите са заредени успешно от файла.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при зареждане на книгите от файла: {ex.Message}");
            }
        }

        public void AddBook(Book book)
        {
            if (bookDictionary.ContainsKey(book.Title))
            {
                Console.WriteLine("Книгата вече съществува в библиотеката.");
                return;
            }

            books.Add(book);
            bookDictionary[book.Title] = book;

            Console.WriteLine("Книгата е успешно добавена в библиотеката.");
        }

        public void RemoveBook(string title)
        {
            Book bookToRemove = books.Find(book => book.Title == title);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                bookDictionary.Remove(title);
                Console.WriteLine("Книгата е премахната успешно.");
            }
            else
            {
                Console.WriteLine("Книгата не е намерена.");
            }
        }

        public void SearchByAuthor(string author)
        {
            List<Book> booksByAuthor = books.FindAll(book => book.Author == author);
            if (booksByAuthor.Count > 0)
            {
                Console.WriteLine($"Намерени книги от автор {author}:");
                foreach (Book book in booksByAuthor)
                {
                    Console.WriteLine($"- {book.Title}");
                }
            }
            else
            {
                Console.WriteLine("Няма намерени книги от този автор.");
            }
        }

        public void SearchByTitle(string title)
        {
            if (bookDictionary.ContainsKey(title))
            {
                Book book = bookDictionary[title];
                Console.WriteLine($"Книга със заглавие '{title}' е намерена:");
                Console.WriteLine($"- Автор: {book.Author}");
                Console.WriteLine($"- Жанр: {book.Genre}");
            }
            else
            {
                Console.WriteLine("Книгата не е намерена.");
            }
        }
        public void SearchByYear(string year)
        {
            List<Book> booksByYear = books.FindAll(book => book.Year == year);
            if (booksByYear.Count > 0)
            {
                Console.WriteLine($"Намерени книги от {year} г.:");
                foreach (Book book in booksByYear)
                {
                    Console.WriteLine($"- {book.Title}");
                }
            }
            else
            {
                Console.WriteLine($"Няма намерени книги написани през {year} г.");
            }

        }
        public void SearchByPageCount(string pageCount)
        {
            List<Book> booksByPageCount = books.FindAll(book => book.PageCount == pageCount);
            if (booksByPageCount.Count > 0)
            {
                Console.WriteLine($"Намерени книги с {pageCount} страници:");
                foreach (Book book in booksByPageCount)
                {
                    Console.WriteLine($"- {book.Title}");
                }
            }
            else
            {
                Console.WriteLine($"Няма намерени книги с {pageCount} страници.");
            }
        }

        public void DisplayAllBooks()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("Всички налични книги:");
                foreach (Book book in books)
                {
                    Console.WriteLine($"- {book.Title,-35} by {book.Author}");
                }
            }
            else
            {
                Console.WriteLine("В библиотеката няма налични книги.");
            }
        }

        public void SaveBooksToFile(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Book book in books)
                    {
                        writer.WriteLine(book.ToString());
                    }
                }

                Console.WriteLine("Книгите са запазени успешно във файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при запазване на книгите във файл: {ex.Message}");
            }
        }
    }
}