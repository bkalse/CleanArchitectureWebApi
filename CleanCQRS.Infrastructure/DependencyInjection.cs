using CleanCQRS.Application.Database;
using CleanCQRS.Application.Repositories;
using CleanCQRS.Infrastructure.Persistance.Database;
using CleanCQRS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanCQRS.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services/*, IConfiguration configuration*/)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddScoped<IApplicatoinDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
