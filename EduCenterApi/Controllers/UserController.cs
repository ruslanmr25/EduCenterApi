using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.DTOs.UserDtos;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    protected readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return Ok(await _userRepository.GetAllAsync(1, 40));

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto userDto)
    {
        User user = new User
        {
            FullName = userDto.FullName,
            Username = userDto.Username,
            Password = userDto.Password,
            RoleId = userDto.RoleId
        };
        await _userRepository.AddAsync(user);
        return NoContent();
    }


}
