

using AutoMapper;
using PostApi.DTOs;
using PostApi.Models;

namespace PostApi.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Post, PostDto>();
            CreateMap<CreatePostDto, Post>();
        }
    }
}