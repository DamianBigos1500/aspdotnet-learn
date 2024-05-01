using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_first.Data;
using dotnet_first.Dtos.CourseCategory;
using dotnet_first.Interfaces;
using dotnet_first.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_first.Repository
{
    public class CourseCategoryRepository(ApplicationDBContext context) : ICourseCategoryRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<CourseCategory> CreateAsync(CourseCategory courseCategoryModel)
        {
            await _context.CourseCategories.AddAsync(courseCategoryModel);
            await _context.SaveChangesAsync();
            return courseCategoryModel;
        }

        public async Task<CourseCategory?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CourseCategory>> GetAllAsync()
        {
            return await _context.CourseCategories.ToListAsync();
        }

        public async Task<CourseCategory?> GetByIdAsync(Guid id)
        {
            return await _context.CourseCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CourseCategory?> UpdateAsync(int id, UpdateCourseCategoryRequestDto CourseCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}