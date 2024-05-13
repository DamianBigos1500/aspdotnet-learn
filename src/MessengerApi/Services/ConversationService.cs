using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Interface;
using MessengerApi.Models;

namespace MessengerApi.Services
{
    public class ConversationService(IConversationRepository conversationRepo) : IConversationService
    {
        private readonly IConversationRepository _conversationRepo = conversationRepo;

        public async Task UpdateLastMessageAsync(Guid senderId, Guid receiverId, Guid messageId)
        {
            var conversation = await GetByUsersOrCreateAsync(senderId, receiverId);
            await _conversationRepo.UpdateLastMessageAsync(conversation.Id, messageId);
        }

        public async Task<Conversation> GetByUsersOrCreateAsync(Guid senderId, Guid receiverId)
        {
            var existingConversation = await _conversationRepo.GetByUsersAsync(senderId, receiverId);
            if (existingConversation != null) return existingConversation;

            var newConversation = new Conversation
            {
                Id = Guid.NewGuid(),
                UserId1 = senderId,
                UserId2 = receiverId,
            };

            return await _conversationRepo.CreateAsync(newConversation);
        }

        public async Task<Conversation> GetByIdAsync(Guid id) => await _conversationRepo.GetByIdAsync(id);

        public async Task<List<Conversation>> GetAllAsync() => await _conversationRepo.GetAllAsync();
    }
}