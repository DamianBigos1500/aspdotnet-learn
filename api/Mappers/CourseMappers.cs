using dotnet_first.Dtos.Course;
using dotnet_first.Models;

namespace dotnet_first.Mappers
{
    public static class CourseMappers
    {
        public static CourseDto ToCourseDto(this Course courseModel)
        {
            return new CourseDto
            {
                Id = courseModel.Id,
                Title = courseModel.Title,
                Description = courseModel.Description,
                Price = courseModel.Price,
                CreatedOn = courseModel.CreatedOn,
                // CreatedBy = commentModel.AppUser.UserName,
                AppUserId = courseModel.AppUserId
            };
        }
        public static Course ToCourseFromCreateDto(this CreateCourseRequestDto courseDto)
        {
            return new Course
            {
                Id = Guid.NewGuid(),
                Title = courseDto.Title,
                Description = courseDto.Description,
                Price = courseDto.Price,
            };

        }
    }
}