using CleanCQRS.Models.Common;

namespace CleanCQRS.Models.Commands.Book
{
    public class CreateBookResponse : Response
    {
        public long Id { get; set; }
        public bool Created { get; set; }
    }
}
