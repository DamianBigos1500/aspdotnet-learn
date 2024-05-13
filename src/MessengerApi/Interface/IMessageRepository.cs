using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Models;

namespace MessengerApi.Interface
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetAllByUserAsync(Guid id);
        Task<List<Message>> GetAllByGroupAsync(Guid id);
        // Task<Message?> GetByIdAsync(int id);
        Task<Message> CreateAsync(Message messageModel);
        // Task<Message?> UpdateAsync(int id, UpdateMessageRequestDto MessageDto);
        Task<Message?> DeleteAsync(Guid id);
        Task<Message?> RestoreAsync(Guid id);
    }
}