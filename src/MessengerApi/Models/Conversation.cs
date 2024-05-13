using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.Models
{
    public class Conversation: BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserId1 { get; set; }
        public Guid UserId2 { get; set; }

        public Guid LastMessageId { get; set; }
    }
}