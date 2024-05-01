using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostApi.Data;
using PostApi.DTOs;

namespace PostApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController(PostDbContext context, IMapper mapper) : ControllerBase
    {
        private readonly PostDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetAllPosts() {
            var posts = await _context.Posts.ToListAsync();

            return _mapper.Map<List<PostDto>>(posts); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetAllPosts(string id)
        {
            var posts = await _context.Posts.FirstOrDefaultAsync(x => x.Id.ToString() == id);

            return _mapper.Map<PostDto>(posts); ;
        }
    }
}