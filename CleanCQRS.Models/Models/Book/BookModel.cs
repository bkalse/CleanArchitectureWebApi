using CleanCQRS.Models.Enums;
using System;

namespace CleanCQRS.Domain.Models.Book
{
    public class BookModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public BookCategory Category { get; set; }
    }
}
