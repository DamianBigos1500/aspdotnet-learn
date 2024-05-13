using MessengerApi.Data;
using MessengerApi.Interface;
using MessengerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MessengerApi.Repository
{
    public class MessageRepository(MessengerDbContext context) : IMessageRepository
    {
        private readonly MessengerDbContext _context = context;

        public async Task<Message> CreateAsync(Message messageModel)
        {
            await _context.Messages.AddAsync(messageModel);

            await _context.SaveChangesAsync();
            return messageModel;
        }

        public async Task<List<Message>> GetAllByGroupAsync(Guid id)
        {
            var userId = Guid.NewGuid();

            return await _context.Messages
            // .Where(m => (m.SenderId == userId && m.ReceiverId == id) || (m.SenderId == id && m.ReceiverId == userId))
            // .OrderByDescending(m => m.CreatedAt)
            // .Take(10)
            .ToListAsync();
        }

        public async Task<List<Message>> GetAllByUserAsync(Guid id)
        {
            return await _context.Messages
            .Where(m => m.GroupId == id)
            .ToListAsync();
        }

        public async Task<Message> DeleteAsync(Guid id)
        {
            var messageModel = await _context.Messages.FirstOrDefaultAsync(x => x.Id == id);
            if (messageModel == null) return null;

            _context.Messages.Remove(messageModel);
            await _context.SaveChangesAsync();

            return messageModel;
        }

        public async Task<Message> RestoreAsync(Guid id)
        {
            var messageModel = await _context.Messages.FirstOrDefaultAsync(x => x.Id == id);
            if (messageModel == null) return null;

            messageModel.DeletedAt = null;
            await _context.SaveChangesAsync();

            return messageModel;
        }
    }
}