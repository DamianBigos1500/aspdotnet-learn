using MessengerApi.DTOs.Message;
using MessengerApi.Models;

namespace MessengerApi.Interface
{
    public interface IMessageService
    {
        Task<List<Message>> GetAllByUserAsync(Guid id);
        Task<List<Message>> GetAllByGroupAsync(Guid id);
        Task<Message> CreateAsync(CreateMessageRequestDto messageDto);

        Task<Message?> DeleteAsync(Guid id);
        Task<Message?> RestoreAsync(Guid id);
    }
}