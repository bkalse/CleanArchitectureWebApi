using CleanCQRS.Application.Database;
using CleanCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanCQRS.Infrastructure.Persistance.Database
{
    public class ApplicationDbContext : DbContext, IApplicatoinDbContext
    {
        public DbSet<Book> Books { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
