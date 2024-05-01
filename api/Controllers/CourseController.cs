using dotnet_first.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using api.Extensions;
using dotnet_first.Interfaces;
using dotnet_first.Mappers;
using dotnet_first.Dtos.Course;


namespace dotnet_first.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController(UserManager<AppUser> userManager, ICourseRepository courseRepo) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ICourseRepository _courseRepo = courseRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseRepo.GetAllAsync();
            var coursesDto = courses.Select(s => s.ToCourseDto());

            return Ok(coursesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var course = await _courseRepo.GetByIdAsync(id);
            if (course == null) return NotFound();

            return Ok(course.ToCourseDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseRequestDto courseDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var courseModel = courseDto.ToCourseFromCreateDto();
            courseModel.AppUserId = appUser.Id;

            await _courseRepo.CreateAsync(courseModel);

            return Ok(courseModel);

        }
    }
}