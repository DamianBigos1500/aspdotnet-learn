using MongoDB.Entities;
using SearchApi.Entities;

namespace SearchApi.Models
{
    public class Post : Entity
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        // public Status Status { get; set; }
        // public List<Comment> Comments { get; set; }
        // public List<Share> Shares { get; set; }
        // public List<Tag> Tags { get; set; }
        // public List<Reaction> Reactions { get; set; }
        // public List<Attachment> Attachments { get; set; }

    }
}