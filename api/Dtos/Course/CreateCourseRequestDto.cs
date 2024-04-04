
using System.ComponentModel.DataAnnotations;

namespace dotnet_first.Dtos.Course
{
    public class CreateCourseRequestDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(0.00, double.MaxValue)]
        public decimal Price { get; set; } = decimal.Zero;
    }
}