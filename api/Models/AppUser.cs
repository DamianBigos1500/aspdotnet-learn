

using Microsoft.AspNetCore.Identity;

namespace dotnet_first.Models
{
    public class AppUser : IdentityUser
    {
        public List<Course> Courses { get; set; } = [];
    }
}