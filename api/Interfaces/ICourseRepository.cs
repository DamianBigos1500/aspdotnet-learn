using dotnet_first.Models;

namespace dotnet_first.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(Guid id);
        Task<List<Course>> GetUserCourses(AppUser user);
        // Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<Course> CreateAsync(Course courseModel);
        Task<Stock?> DeleteAsync(Guid id);
    }
}