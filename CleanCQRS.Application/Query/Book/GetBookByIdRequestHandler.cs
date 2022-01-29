using CleanCQRS.Application.Common;
using CleanCQRS.Application.Repositories;
using CleanCQRS.Models.Queries.Book.GetBookById;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCQRS.Application.Query.Book
{
    public class GetBookByIdRequestHandler : CommonRequestHandler<GetBookByIdRequest, GetBookByIdResponse>
    {
        public readonly IBookRepository _bookRepository;

        public GetBookByIdRequestHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        protected override async Task<GetBookByIdResponse> Execute(GetBookByIdRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetPropertyById(request.Id);

            if (book == null)
            {
                var response = new GetBookByIdResponse()
                {
                    Errors = new string[] {"Book doesn't exist." },
                    Succeeded = false
                };

                return response;
            }

            return new GetBookByIdResponse() 
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Category = (Models.Enums.BookCategory)book.Category,
                Publisher = book.Publisher,
                PublishedDate = book.PublishedDate
            };
        }
    }
}
