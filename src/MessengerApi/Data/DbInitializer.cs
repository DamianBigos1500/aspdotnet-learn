using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MessengerApi.Models;

namespace MessengerApi.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<MessengerDbContext>());
        }

        private static void SeedData(MessengerDbContext context)
        {
            context.Database.Migrate();

            if (context.Groups.Any() && context.Messages.Any())
            {
                Console.WriteLine("Already have data");
                return;
            }

            var groups = new List<Group>() {
                new() {
                    Id = Guid.NewGuid(),
                    Name = "First post name",
                    Description = "First post description",
                    OwnerId = Guid.NewGuid(),
                }
            };

            var messages = new List<Message>() {
                new() {
                    Id = Guid.NewGuid(),
                    MessageText = "First msg name",
                    SenderId = Guid.NewGuid(),
                    ReceiverId= Guid.NewGuid(),
                    ConversationId = Guid.NewGuid(),
                    GroupId = Guid.NewGuid(),
                },
                new() {
                    Id = Guid.NewGuid(),
                    MessageText = "First msg name",
                    SenderId = Guid.NewGuid(),
                    ReceiverId= Guid.NewGuid(),
                    ConversationId = Guid.NewGuid(),
                    GroupId = Guid.NewGuid(),
                },
                new() {
                    Id = Guid.NewGuid(),
                    MessageText = "First msg name",
                    SenderId = Guid.NewGuid(),
                    ReceiverId= Guid.NewGuid(),
                    ConversationId = Guid.NewGuid(),
                    GroupId = Guid.NewGuid(),
                },

            };

            context.AddRange(groups, messages);
            context.SaveChanges();

        }


    }
}