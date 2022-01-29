using CleanCQRS.Models.Common;
using CleanCQRS.Models.Enums;
using System;

namespace CleanCQRS.Models.Queries.Book.GetBookById
{
    public class GetBookByIdResponse : Response
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public BookCategory Category { get; set; }
    }
}
