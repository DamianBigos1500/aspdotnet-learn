using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_first.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = decimal.Zero;
        public bool IsPublished { get; set; }

        // public string CategoryId { get; set; } = string.Empty;
        // public CourseCategory? Category { get; set; }

        // public List<CourseChapter> Chapters { get; set; } = [];
        // public ICollection<Attachment> Attachments { get; set; }
        // public List<CoursePurchase> Purchases { get; set; } = [];

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}