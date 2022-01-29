using CleanCQRS.Application.Common;
using CleanCQRS.Application.Repositories;
using CleanCQRS.Domain.Models.Book;
using CleanCQRS.Models.Queries.Book.GetBooks;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCQRS.Application.Query.Book
{
    public class GetBooksRequestHandler : CommonRequestHandler<GetBooksRequest, GetBooksResponse>
    {
        public readonly IBookRepository _bookRepository;

        public GetBooksRequestHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        protected override async Task<GetBooksResponse> Execute(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooks();
            var bookList = new List<BookModel>();
            books.ForEach(book => bookList.Add(new BookModel() 
                                                {
                                                    Id = book.Id,
                                                    Title = book.Title, 
                                                    Author = book.Author, 
                                                    Category = (Models.Enums.BookCategory)book.Category, 
                                                    Publisher = book.Publisher, 
                                                    PublishedDate = book.PublishedDate  
                                                }));

            var response = new GetBooksResponse();
            response.Books.AddRange(bookList);
            return response;
        }
    }
}
