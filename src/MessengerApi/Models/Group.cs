using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.Models
{
    public class Group: BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        // public string Owner { get; set; }

        public Guid LastMessageId { get; set; }

    }
}