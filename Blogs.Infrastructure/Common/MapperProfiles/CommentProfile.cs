using AutoMapper;
using Blogs.Application.Dtos;
using Blogs.Domain.Entities;

namespace Blogs.Infrastructure.Common.MapperProfiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.Date, options
                => options.MapFrom(src => src.ModifiedTime != null ? src.ModifiedTime : src.CreatedTime))
            .ReverseMap();
    }
}