using MessengerApi.DTOs.Message;
using MessengerApi.Interface;
using MessengerApi.Mappers;
using MessengerApi.Models;

namespace MessengerApi.Services
{
    public class MessageService(IMessageRepository messageRepo, IConversationService conversationService, IGroupService groupService) : IMessageService
    {
        private readonly IMessageRepository _messageRepo = messageRepo;
        private readonly IConversationService _conversationService = conversationService;
        private readonly IGroupService _groupService = groupService;


        public List<Guid> datas = [
            Guid.Parse("a3b44831-d42d-417b-b305-ffa99774b5dd"),
            Guid.Parse("c368c3b9-50f1-4ca0-a639-a8136b2d4213"),
            Guid.Parse("3d7aa431-f25c-4f0c-bb41-832eeb342a4a"),
            Guid.Parse("30df328c-3e10-4889-bda5-0db1db4cbac6"),
            Guid.Parse("1093d064-98dd-41f0-9695-d38952bbcebb"),
            Guid.Parse("f0c08c58-6e0c-440d-b925-f20496e34482"),
            Guid.Parse("171f15f7-4237-47f8-a9f2-c8e7e36d3371"),
            Guid.Parse("c1362b5a-65a6-423b-9be1-c788650ba1b1"),
            Guid.Parse("1df1456c-b90e-4ee4-a36e-a7eaa7997bca"),
            Guid.Parse("1993d819-217a-4aa6-9713-7fe29944dfe7"),
        ];


        public async Task<List<Message>> GetAllByUserAsync(Guid userId) => await _messageRepo.GetAllByGroupAsync(userId);

        public async Task<List<Message>> GetAllByGroupAsync(Guid groupId) => await _messageRepo.GetAllByGroupAsync(groupId);

        public async Task<Message> CreateAsync(CreateMessageRequestDto messageDto)
        {
            var messageModel = messageDto.ToMessageFromCreateDto();
            if (messageModel.GroupId != null)
            {
                var group = await _groupService.GetByIdAsync((Guid)messageModel.GroupId);
                if (group == null) return null;
            }

            messageModel.SenderId = Guid.NewGuid();
            messageModel.ConversationId = Guid.NewGuid();
            await _messageRepo.CreateAsync(messageModel);

            if (messageModel.ReceiverId != null)
            {
                Random rand = new();
                Random rand2 = new();
                await _conversationService.UpdateLastMessageAsync(datas[rand2.Next(0,3)], datas[rand.Next(4, datas.Count - 1)], messageModel.Id);
            }

            if (messageModel.GroupId != null)
            {
                await _groupService.UpdateLastMessageAsync((Guid)messageModel.GroupId, messageModel.Id);
            }

            return messageModel;
        }

        public async Task<Message> DeleteAsync(Guid id) => await _messageRepo.DeleteAsync(id);
        public async Task<Message> RestoreAsync(Guid id) => await _messageRepo.RestoreAsync(id);
    }
}