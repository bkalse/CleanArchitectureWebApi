using CleanCQRS.Application.Common;
using CleanCQRS.Application.Repositories;
using CleanCQRS.Application.Validators.Book;
using CleanCQRS.Models.Commands.Book;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCQRS.Application.Commands.Book
{
    public class CreateBookCommandHandler : CommonRequestHandler<CreateBookCommand, CreateBookResponse>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        protected override async Task<CreateBookResponse> Execute(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var property = new Domain.Entities.Book()
            {
                Title = request.Title,
                Publisher = request.Publisher,
                Author = request.Author,
                Category = (Domain.Enums.BookCategory)request.Category,
                PublishedDate = request.PublishedDate
            };

            // Validate the entity
            var validator = new BookValidator();
            var result = validator.Validate(property);

            if (!result.IsValid)
            {
                var response = new CreateBookResponse()
                {
                    Errors = result.Errors.Select(e => e.ToString()).ToArray(),
                    Succeeded = false,
                    Message = result.ToString()
                };

                return response;
            }

            var id = await _bookRepository.CreateBook(property);
            return new CreateBookResponse() { Id = id, Created = id > 0 };
        }
    }
}
