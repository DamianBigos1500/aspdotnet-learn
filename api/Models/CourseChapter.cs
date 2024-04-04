using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_first.Models
{
    public class CourseChapter
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public int Position { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFree { get; set; }
        // public CourseMuxData? MuxData { get; set; }
        public Course? Course { get; set; }
        public List<UserProgress> UserProgress { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}