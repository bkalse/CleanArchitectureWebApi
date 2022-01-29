using CleanCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanCQRS.Application.Database
{
    public interface IApplicatoinDbContext
    {
        DbSet<Book> Books { get; set; }

        Task<int> SaveChangesAsync();
    }
}
