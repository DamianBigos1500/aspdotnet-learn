using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_first.Models
{
    public class UserProgress
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public CourseChapter? Chapter { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}