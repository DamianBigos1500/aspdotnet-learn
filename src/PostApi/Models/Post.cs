using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PostApi.Entities;

namespace PostApi.Models
{
    [Table("Posts")]
    public class Post
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Status Status { get; set; }
        public List<Comment> Comments { get; set; }
        // public List<Share> Shares { get; set; }
        // public List<Tag> Tags { get; set; }
        // public List<Reaction> Reactions { get; set; }
        public List<Attachment> Attachments { get; set; }

    }
}