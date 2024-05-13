using MessengerApi.Models;

namespace MessengerApi.Interface
{
    public interface IGroupService
    {
        Task<Group> GetByIdAsync(Guid id);
        Task<Group> UpdateLastMessageAsync(Guid groupId, Guid messageId);
    }
}