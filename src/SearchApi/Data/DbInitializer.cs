using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchApi.Models;

namespace SearchApi.Data
{
    public class DbInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            await DB.InitAsync("SearchDb",
                MongoClientSettings
                .FromConnectionString(
                    app
                    .Configuration
                    .GetConnectionString("MongoDbConnection")
                )
            );

            await DB.Index<Post>()
                .Key(x => x.ID, KeyType.Text)
                .Key(x => x.Text, KeyType.Text)
                .CreateAsync();

            var count = await DB.CountAsync<Post>();

            if (count == 0)
            {
                Console.WriteLine("No data -- will attempt to seed");
                var itemData = await File.ReadAllTextAsync("Data/posts.json");

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var item = JsonSerializer.Deserialize<List<Post>>(itemData, options);

                await DB.SaveAsync(item);
            }
        }
    }
}