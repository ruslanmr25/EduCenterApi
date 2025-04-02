using AutoMapper;
using EduCenterApi.Application.Abstractions.Hasher;
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.DTOs.UserDtos;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.SuperAdmin;

[Route("api/super-admin/users")]
[ApiController]
public class UserController : ControllerBase
{

    protected readonly IUserRepository _userRepository;

    protected readonly IMapper _mapper;

    protected readonly IPasswordHasher _passwordHasher;
    public UserController(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }


    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 40)
    {
        return Ok(await _userRepository.GetAllAsync(page, pageSize));

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);

        user.Password = _passwordHasher.Hashing(user.Password);
        await _userRepository.AddAsync(user);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto userDto)
    {
        User? user = await _userRepository.GetByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _mapper.Map(userDto, user);

        if (userDto.Password != null)
        {
            user.Password = _passwordHasher.Hashing(userDto.Password);
        }
        await _userRepository.UpdateAsync(user);
        return Ok();
    }


    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    await _userRepository.DeleteAsync(id);
    //    return Ok();
    //}


}
