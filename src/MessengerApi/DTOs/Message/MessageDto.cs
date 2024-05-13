using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.DTOs.Message
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public Guid SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid? ConversationId { get; set; }
        public Guid? GroupId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }
}