using dotnet_first.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_first.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : IdentityDbContext(dbContextOptions)
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}