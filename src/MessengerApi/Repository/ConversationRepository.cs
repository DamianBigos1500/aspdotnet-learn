using MessengerApi.Data;
using MessengerApi.Interface;
using MessengerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MessengerApi.Repository
{
    public class ConversationRepository(MessengerDbContext context) : IConversationRepository
    {
        private readonly MessengerDbContext _context = context;


        public async Task<Conversation> CreateAsync(Conversation conversationModel)
        {
            await _context.Conversations.AddAsync(conversationModel);

            await _context.SaveChangesAsync();
            return conversationModel;
        }


        public Task<List<Conversation>> GetAllAsync()
        {
            return _context.Conversations.ToListAsync();
        }


        public async Task<Conversation> GetByIdAsync(Guid id)
        {
            return await _context.Conversations.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Conversation> GetByUsersAsync(Guid SenderId, Guid ReceiverId)
        {
            return await _context.Conversations.FirstOrDefaultAsync(x =>
                (x.UserId1 == SenderId && x.UserId2 == ReceiverId) ||
                (x.UserId1 == ReceiverId && x.UserId2 == SenderId)
               );
        }


        public async Task<Conversation> UpdateLastMessageAsync(Guid conversationId, Guid messageId)
        {
            var existingConversation = await _context.Conversations.FirstOrDefaultAsync(x => x.Id == conversationId);
            if (existingConversation == null) return null;

            existingConversation.LastMessageId = messageId;
            await _context.SaveChangesAsync();

            return existingConversation;
        }
    }
}