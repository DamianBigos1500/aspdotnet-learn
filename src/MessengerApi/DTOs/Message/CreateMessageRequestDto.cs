using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.DTOs.Message
{
    public class CreateMessageRequestDto
    {
        public string MessageText { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid? GroupId { get; set; }
    }
}