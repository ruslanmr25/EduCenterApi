
using AutoMapper;
using EduCenterApi.Application.DTOs.UserDtos;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.Mapper;

public class MainMapper : Profile
{

    public MainMapper()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, CreateUserDto>();

        CreateMap<UpdateUserDto, User>()
    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<User, UpdateUserDto>();

    }
}
