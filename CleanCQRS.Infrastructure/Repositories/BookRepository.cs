using CleanCQRS.Application.Database;
using CleanCQRS.Application.Exceptions;
using CleanCQRS.Application.Repositories;
using CleanCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCQRS.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IApplicatoinDbContext _context;

        public BookRepository(IApplicatoinDbContext context)
        {
            _context = context;
        }

        public async Task<long> CreateBook(Book book)
        {
            if (isDuplicateTitle(book.Title))
                throw new DuplicateBookTitleException(book.Title);

            _ = await _context.Books.AddAsync(book);
            var a = await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<List<Book>> GetBooks()
        {
            var books = await _context.Books.Where(p => p.IsDeleted == false).ToListAsync();

            if (books == null || books.Count == 0)
                return new List<Book>();

            return books;
        }

        public async Task<Book> GetPropertyById(long bookId)
        {
            var book = await _context.Books.Where(b => b.IsDeleted == false && b.Id == bookId).FirstOrDefaultAsync();

            if (book == null)
                return default;

            return book;
        }


        #region Private Methods

        private bool isDuplicateTitle(string title)
        {
            var book = _context.Books.Where(p => p.IsDeleted == false && p.Title == title).FirstOrDefault();
            return book != null;
        }

        #endregion
    }
}
