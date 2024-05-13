using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Interface;

namespace MessengerApi.Models
{
    public class Message : BaseEntity, ISoftDeletes
    {
        public Guid Id { get; set; }
        public string MessageText { get; set; }
        public Guid SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid? ConversationId { get; set; }
        public Guid? GroupId { get; set; }
    }
}