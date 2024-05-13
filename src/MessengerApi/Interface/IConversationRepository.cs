using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Models;

namespace MessengerApi.Interface
{
    public interface IConversationRepository
    {

          Task<List<Conversation>> GetAllAsync();
          Task<Conversation> GetByIdAsync(Guid id);
          Task<Conversation> GetByUsersAsync(Guid SenderId, Guid ReceiverId);
          Task<Conversation> CreateAsync(Conversation conversationModel);
          Task<Conversation> UpdateLastMessageAsync(Guid conversationId, Guid messageId);
    }
}