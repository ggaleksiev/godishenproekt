using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace godishenproekt
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string PageCount { get; set; }


        public Book(string title, string author, string genre, string year, string pageCount)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            PageCount = pageCount;
        }

        public override string ToString()
        {
            return $"{Title}, {Author}, {Genre}, {Year}, {PageCount}";
        }
    }
}