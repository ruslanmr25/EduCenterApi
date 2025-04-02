
using AutoMapper;
using EduCenterApi.Application.DTOs.CenterDtos;
using EduCenterApi.Application.DTOs.UserDtos;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.Mapper;

public class MainMapper : Profile
{

    public MainMapper()
    {
        CreateMap<CreateUserDto, User>();
       
        CreateMap<UpdateUserDto, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<User, UpdateUserDto>();





        //center
        CreateMap<CreateCenterDto, Center>();
        CreateMap<UpdateCenterDto, Center>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

    }
}
