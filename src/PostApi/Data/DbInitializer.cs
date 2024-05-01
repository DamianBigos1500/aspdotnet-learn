using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostApi.Entities;
using PostApi.Models;

namespace PostApi.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<PostDbContext>());
        }

        private static void SeedData(PostDbContext context)
        {
            context.Database.Migrate();

            if (context.Posts.Any())
            {
                Console.WriteLine("Already have data");
                return;
            }

            var posts = new List<Post>() {
                new() {
                    Id = Guid.NewGuid(),
                    Text = "First post",
                    Status = Status.Published
                }
            };

            context.AddRange(posts);
            context.SaveChanges();

        }


    }
}