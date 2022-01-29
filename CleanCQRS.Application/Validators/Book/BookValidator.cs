using FluentValidation;

namespace CleanCQRS.Application.Validators.Book
{
    public class BookValidator : AbstractValidator<Domain.Entities.Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title).Cascade(CascadeMode.Stop).NotEmpty().Length(2, 64);
            RuleFor(book => book.Publisher).Cascade(CascadeMode.Stop).NotEmpty().Length(2, 256);
        }
    }
}
