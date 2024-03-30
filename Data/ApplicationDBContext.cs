using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_first.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_first.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Stock> Comment { get; set; }
    }
}