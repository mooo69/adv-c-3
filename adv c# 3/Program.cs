using System;
using System.Collections.Generic;

namespace Assignment03
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<Book> books = new List<Book>
            {
                new Book("C# Basics", "Author A", "Publisher X", 2019, 200, 50m),
                new Book("Advanced C#", "Author B", "Publisher Y", 2021, 300, 75m),
                new Book("LINQ in Depth", "Author C", "Publisher Z", 2020, 250, 60m)
            };

            LibraryEngine.ProcessBooks(books, BookFunctions.GetTitle);
            Console.WriteLine("----------------------");
            LibraryEngine.ProcessBooks(books, BookFunctions.GetAuthors);
            Console.WriteLine("----------------------");
            LibraryEngine.ProcessBooks(books, delegate (Book b) { return b.Price.ToString(); });
            Console.WriteLine("----------------------");
            LibraryEngine.ProcessBooks(books, b => b.ISBN);

            
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public string ISBN { get; set; }

        public Book(string title, string authors, string publisher, int year, int month, decimal price)
        {
            Title = title;
            Authors = authors;
            Publisher = publisher;
            PublicationDate = new DateTime(year, month, 1);
            Price = price;
            ISBN = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Title}, {Authors}, {Publisher}, {PublicationDate.ToShortDateString()}, {Price:C}, {ISBN}";
        }
    }

    public static class BookFunctions
    {
        public static string GetTitle(Book b) => b.Title;
        public static string GetAuthors(Book b) => b.Authors;
        public static string GetPublisher(Book b) => b.Publisher;
    }

    public delegate string BookDelegate(Book b);

    public static class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, BookDelegate fptr)
        {
            foreach (Book b in bList)
            {
                Console.WriteLine(fptr(b));
            }
        }
    }
}
