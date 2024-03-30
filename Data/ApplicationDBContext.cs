using dotnet_first.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_first.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Stock> Comments { get; set; }
    }
}