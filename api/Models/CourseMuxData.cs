using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_first.Models
{
    public class CourseMuxData
    {
        public Guid Id { get; set; }
        public string AssetId { get; set; } = string.Empty;
        public string PlaybackId { get; set; } = string.Empty;
        public CourseChapter? Chapter { get; set; }
    }
}