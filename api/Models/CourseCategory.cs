using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_first.Models
{
    public class CourseCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = [];
    }
}