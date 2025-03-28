using AutoMapper;
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

    protected readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return Ok(await _userRepository.GetAllAsync(1, 40));

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto userDto)
    {
        User user =_mapper.Map<User>(userDto);
        await _userRepository.AddAsync(user);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto userDto)
    {
        return Ok(userDto);
        User user = _mapper.Map<User>(userDto);
        user.Id = id;

        await _userRepository.UpdateAsync(user);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userRepository.DeleteAsync(id);
        return Ok();
    }


}
