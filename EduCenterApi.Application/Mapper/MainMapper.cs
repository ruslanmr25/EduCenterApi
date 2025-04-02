
using AutoMapper;
using EduCenterApi.Application.DTOs.CenterDtos;
using EduCenterApi.Application.DTOs.GroupDto;
using EduCenterApi.Application.DTOs.ScienceDto;
using EduCenterApi.Application.DTOs.TeacherDto;
using EduCenterApi.Application.DTOs.UserDtos;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.Mapper;

public class MainMapper : Profile
{

    public MainMapper()
    {
        CreateMap<CreateTeacherDto, User>();


        CreateMap<UpdateTeacherDto, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));




        CreateMap<CreateUserDto, User>();


        CreateMap<UpdateUserDto, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));



        CreateMap<User, UpdateUserDto>();





        //center
        CreateMap<CreateCenterDto, Center>();
        CreateMap<UpdateCenterDto, Center>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));


        CreateMap<CreateScienceDto, Since>();
        CreateMap<UpdateScienceDto, Since>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<CreateGroupDto, Group>();


        CreateMap<UpdateGroupDto, Group>()
     .ForMember(dest => dest.TeacherId, opt => opt.Condition(src => src.TeacherId.HasValue))
     .ForMember(dest => dest.SinceId, opt => opt.Condition(src => src.SinceId.HasValue))
     .ForMember(dest => dest.TeacherPortion, opt => opt.Condition(src => src.TeacherPortion.HasValue))
     .ForMember(dest => dest.Price, opt => opt.Condition(src => src.Price.HasValue));

    }
}
