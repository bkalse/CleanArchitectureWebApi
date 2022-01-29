using CleanCQRS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanCQRS.Application.Repositories
{
    public interface IBookRepository
    {
        Task<long> CreateBook(Book book);
        Task<List<Book>> GetBooks();
        Task<Book> GetPropertyById(long bookId);
    }
}
