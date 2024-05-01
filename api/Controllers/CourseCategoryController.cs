using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_first.Dtos.CourseCategory;
using dotnet_first.Interfaces;
using dotnet_first.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_first.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseCategoryController(ICourseCategoryRepository courseCatRepo) : ControllerBase
    {
        private readonly ICourseCategoryRepository _courseCatRepo = courseCatRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courseCategories = await _courseCatRepo.GetAllAsync();
            var courseCategoriesDto = courseCategories.Select(s => s.ToCourseCategoryDto());
            return Ok(courseCategoriesDto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var courseCategory = await _courseCatRepo.GetByIdAsync(id);
            if (courseCategory == null) return NotFound();

            return Ok(courseCategory.ToCourseCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseCategoryRequestDto courseCategoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var courseCategoryModel = courseCategoryDto.ToCourseCategoryFromCreateDto();
            await _courseCatRepo.CreateAsync(courseCategoryModel);

            return Ok(courseCategoryModel.ToCourseCategoryDto());

        }
    }
}