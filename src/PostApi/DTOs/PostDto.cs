using PostApi.Entities;
using PostApi.Models;

namespace PostApi.DTOs
{
    public class PostDto
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