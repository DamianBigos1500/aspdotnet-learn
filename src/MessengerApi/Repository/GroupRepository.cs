
using MessengerApi.Data;
using MessengerApi.Interface;
using MessengerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MessengerApi.Repository
{
    public class GroupRepository(MessengerDbContext context) : IGroupRepository
    {
        private readonly MessengerDbContext _context = context;


        public async Task<Group> GetByIdAsync(Guid id)
        {
            return await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Group> CreateAsync(Group groupModel)
        {
            await _context.Groups.AddAsync(groupModel);

            await _context.SaveChangesAsync();
            return groupModel;
        }

        public async Task<Group> UpdateLastMessageAsync(Guid groupId, Guid messageId)
        {
            var existingGroup = await _context.Groups.FirstOrDefaultAsync(x => x.Id == groupId);
            if (existingGroup == null) return null;

            existingGroup.LastMessageId = messageId;
            await _context.SaveChangesAsync();

            return existingGroup;
        }
    }
}