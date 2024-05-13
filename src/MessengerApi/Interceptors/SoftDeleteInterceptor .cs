using MessengerApi.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MessengerApi.Interceptors
{
    public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null)
            {
                return base.SavingChangesAsync(
                    eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<ISoftDeletes>> entries =
                eventData
                    .Context
                    .ChangeTracker
                    .Entries<ISoftDeletes>()
                    .Where(e => e.State == EntityState.Deleted);

            foreach (EntityEntry<ISoftDeletes> softDeletes in entries)
            {
                softDeletes.State = EntityState.Modified;
                softDeletes.Entity.DeletedAt = DateTime.UtcNow;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}