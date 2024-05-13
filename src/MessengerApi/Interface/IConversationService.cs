using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Models;

namespace MessengerApi.Interface
{
    public interface IConversationService
    {
        Task<List<Conversation>> GetAllAsync();
        Task<Conversation> GetByIdAsync(Guid id);
        Task UpdateLastMessageAsync(Guid senderId, Guid receiverId, Guid messageId);
        
    }
}