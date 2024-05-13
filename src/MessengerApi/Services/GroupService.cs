
using MessengerApi.Interface;
using MessengerApi.Models;

namespace MessengerApi.Services
{
    public class GroupService(IGroupRepository groupRepo): IGroupService
    {
        private readonly IGroupRepository _groupRepo = groupRepo;

        public async Task<Group> GetByIdAsync(Guid id)
        {
            return await _groupRepo.GetByIdAsync(id);
        }

        public async Task<Group> UpdateLastMessageAsync(Guid conversationId, Guid messageId)
        {
            return await _groupRepo.UpdateLastMessageAsync(conversationId, messageId);
        }

    }
}