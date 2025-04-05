using AutoMapper;
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.DTOs.StudentDto;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.CenterAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        protected int CenterId = 1;

        protected IMapper _mapper;
        protected readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int page=1,int pageSize=40)
        {

            var students=await _studentRepository.GetAllByCenter(CenterId, null, page,pageSize);
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto createStudentDto)
        {
            Student student = _mapper.Map<Student>(createStudentDto);

            await _studentRepository.AddAsync(student);

            await _studentRepository.AttachStudent(student, createStudentDto.GroupIds);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
     
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto updateStudentDto)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _mapper.Map(updateStudentDto, student);
            await _studentRepository.UpdateAsync(student);
            if(updateStudentDto.GroupIds != null)
            {
                await _studentRepository.AttachStudent(student, updateStudentDto.GroupIds);
            }
            return Ok();
        }



    }
}
