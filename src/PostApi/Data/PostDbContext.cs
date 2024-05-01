using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostApi.Models;

namespace PostApi.Data
{
    public class PostDbContext(DbContextOptions<PostDbContext> options) : DbContext(options)
    {

        public DbSet<Post> Posts { get; set; }
    }
}