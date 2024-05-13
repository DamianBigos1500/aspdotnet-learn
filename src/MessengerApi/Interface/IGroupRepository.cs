using MessengerApi.Models;

namespace MessengerApi.Interface
{
    public interface IGroupRepository
    {
        Task<Group> GetByIdAsync(Guid id);
        Task<Group> CreateAsync(Group groupModel);
        Task<Group> UpdateLastMessageAsync(Guid conversationId, Guid messageId);
    }
}