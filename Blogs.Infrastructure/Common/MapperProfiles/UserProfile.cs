using AutoMapper;
using Blogs.Application.Dtos;
using Blogs.Application.Identity.Models;
using Blogs.Domain.Entities;

namespace Blogs.Infrastructure.Common.MapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<SignUpDetails, UserProfile>();
        CreateMap<User, UserDto>().ReverseMap();
    }
}