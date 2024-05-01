using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_first.Dtos.CourseCategory;
using dotnet_first.Models;

namespace dotnet_first.Interfaces
{
    public interface ICourseCategoryRepository
    {
        Task<List<CourseCategory>> GetAllAsync();
        Task<CourseCategory?> GetByIdAsync(Guid id);
        Task<CourseCategory> CreateAsync(CourseCategory courseCategoryModel);
        Task<CourseCategory?> UpdateAsync(int id, UpdateCourseCategoryRequestDto CourseCategoryDto);
        Task<CourseCategory?> DeleteAsync(int id);
    }
}