using dotnet_first.Data;
using dotnet_first.Interfaces;
using dotnet_first.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_first.Repository
{
    public class CourseRepository(ApplicationDBContext context) : ICourseRepository
    {
        private readonly ApplicationDBContext _context = context;


        public async Task<Course> CreateAsync(Course courseModel)
        {
            await _context.Courses.AddAsync(courseModel);
            await _context.SaveChangesAsync();
            return courseModel;
        }

        public Task<Stock?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Course>> GetUserCourses(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}