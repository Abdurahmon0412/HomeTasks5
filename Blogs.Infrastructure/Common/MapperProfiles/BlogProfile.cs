using AutoMapper;
using Blogs.Application.Dtos;
using Blogs.Domain.Entities;

namespace Blogs.Infrastructure.Common.MapperProfiles;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<BlogDto, Blog>();
        CreateMap<Blog, BlogDto>();
    }
}
