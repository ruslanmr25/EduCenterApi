using AutoMapper;
using EduCenterApi.Application.Abstractions.Hasher;
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.DTOs.TeacherDto;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.CenterAdmin
{

    [Route("api/center-admin/teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        protected int CenterId = 5;

        protected readonly IUserRepository _userRepository;

        protected readonly IMapper _mapper;

        protected IPasswordHasher _passwordHasher;






        public TeacherController(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            this._userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 40)
        {


            return Ok(await _userRepository.GetAllTeacherAsync(CenterId, page, pageSize));

        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateTeacherDto createTeacherDto)
        {
            User user = _mapper.Map<User>(createTeacherDto);

            user.RoleId = 3;
            user.TeacherCenters = new List<TeacherCenter> { new TeacherCenter { CenterId = CenterId } };

            user.Password = _passwordHasher.Hashing(user.Password);
            await _userRepository.AddAsync(user);
            return Ok();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Show(int id)
        {
            User? user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTeacherDto updateTeacherDto)
        {
            User? user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _mapper.Map(updateTeacherDto, user);
            if (updateTeacherDto.Password != null)
            {
                user.Password = _passwordHasher.Hashing(updateTeacherDto.Password);
            }
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
}
