using MessengerApi.DTOs.Message;
using MessengerApi.Models;

namespace MessengerApi.Mappers
{
    public static class MessageMapper
    {
        public static MessageDto ToMessageDto(this Message messageModel)
        {
            return new MessageDto
            {
                Id = messageModel.Id,
                MessageText = messageModel.MessageText,
                SenderId = messageModel.SenderId,
                ReceiverId = messageModel.ReceiverId,
                ConversationId = messageModel.ConversationId,
                GroupId = messageModel.GroupId,
                CreatedAt = messageModel.CreatedAt,
                UpdatedAt = messageModel.UpdatedAt,
            };
        }
        public static Message ToMessageFromCreateDto(this CreateMessageRequestDto messageDto)
        {
            return new Message
            {
                Id = Guid.NewGuid(),
                MessageText = messageDto.MessageText,
                ReceiverId = messageDto.ReceiverId,
                GroupId = messageDto.GroupId,
            };
        }
    }
}