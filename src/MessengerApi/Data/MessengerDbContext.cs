using MessengerApi.Interface;
using MessengerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MessengerApi.Data
{
    public class MessengerDbContext(DbContextOptions<MessengerDbContext> options) : DbContext(options)
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        public override int SaveChanges()
        {
            var currentTime = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;

                // if (entry.State == EntityState.Added)
                // {
                //     entity.CreatedAt = currentTime;
                //     entity.UpdatedAt = currentTime;
                // }

                // if (entry.State == EntityState.Modified)
                // {
                //     Entry(entity).Property(e => e.CreatedAt).IsModified = false;
                //     entity.UpdatedAt = currentTime;
                // }

                if (entry.State == EntityState.Deleted && entity is ISoftDeletes)
                {
                    entry.State = EntityState.Modified;
                    entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
                }
            }

            return base.SaveChanges();
        }
    }
}