using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_first.Models
{
    public class CoursePurchase
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public Course? Course { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}