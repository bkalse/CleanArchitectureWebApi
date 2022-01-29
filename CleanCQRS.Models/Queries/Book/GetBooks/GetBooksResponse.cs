using CleanCQRS.Domain.Models.Book;
using CleanCQRS.Models.Common;
using System.Collections.Generic;

namespace CleanCQRS.Models.Queries.Book.GetBooks
{
    public class GetBooksResponse : Response
    {
        public List<BookModel> Books { get; set; } = new();
    }
}
