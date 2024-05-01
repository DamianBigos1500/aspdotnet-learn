using dotnet_first.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_first.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions) : IdentityDbContext<AppUser>(dbContextOptions)
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<Course>(x => x.HasKey(p => new { p.AppUserId }));

            // builder.Entity<Course>()
            //     .HasOne(u => u.AppUser)
            //     .WithMany(u => u.Courses)
            //     .HasForeignKey(u => u.AppUserId);

            List<IdentityRole> roles =
            [
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole
                {
                    Name="User",
                    NormalizedName="USER"
                }
            ];
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}