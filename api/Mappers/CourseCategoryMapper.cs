using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_first.Dtos.CourseCategory;
using dotnet_first.Models;

namespace dotnet_first.Mappers
{
    public static class CourseCategoryMapper
    {
        public static CourseCategoryDto ToCourseCategoryDto(this CourseCategory courseCategoryModel)
        {
            return new CourseCategoryDto
            {
                Id = courseCategoryModel.Id,
                Name = courseCategoryModel.Name,
            };
        }
        public static CourseCategory ToCourseCategoryFromCreateDto(this CreateCourseCategoryRequestDto courseCategoryDto)
        {
            return new CourseCategory
            {
                Id = Guid.NewGuid(),
                Name = courseCategoryDto.Name,
            };
        }
    }
}