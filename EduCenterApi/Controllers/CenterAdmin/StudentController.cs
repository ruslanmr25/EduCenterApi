using AutoMapper;
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.DTOs.StudentDto;
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.CenterAdmin;

[Route("api/center-admin/students")]
[ApiController]
public class StudentController : ControllerBase
{
    protected int CenterId = 5;

    protected IStudentPaymentSycleRepository _studentPaymentSycleRepository;

    protected IGroupRepository _groupRepository;

    protected IMapper _mapper;
    protected readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository, IMapper mapper, IStudentPaymentSycleRepository studentPaymentSycleRepository, IGroupRepository groupRepository)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _studentPaymentSycleRepository = studentPaymentSycleRepository;
        _groupRepository = groupRepository;
    }


    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 40)
    {

        var students = await _studentRepository.GetAllByCenter(CenterId, null, page, pageSize);

        List<IndexStudentDto> items = _mapper.Map<List<IndexStudentDto>>(students.Items);


        var response = new PagedResult<IndexStudentDto>(items, students.TotalCount, students.TotalPages, students.PageSize);


        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentDto createStudentDto)
    {
        Student student = _mapper.Map<Student>(createStudentDto);

        await _studentRepository.AddAsync(student);

        await _studentRepository.AttachStudent(student, createStudentDto.GroupIds);



        DateOnly beginDate = createStudentDto.BeginSycleDate ?? DateOnly.FromDateTime(DateTime.Now);
        DateOnly nextDate = beginDate.AddMonths(1);

        foreach (int groupId in createStudentDto.GroupIds)
        {
            Group? group = await _groupRepository.GetByIdAsync(groupId);
            await _studentPaymentSycleRepository.AddStudentPaymentSycleAsync(student.Id, group.Id, group.Price, beginDate, nextDate);
        }

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

        //hamma guruh idsi kelish kerak yangisi ham eskisi ham 
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        _mapper.Map(updateStudentDto, student);
        await _studentRepository.UpdateAsync(student);
        if (updateStudentDto.GroupIds != null)
        {
            await _studentPaymentSycleRepository.UpdateSycleAsync(student.Id, updateStudentDto.GroupIds);
            await _studentRepository.AttachStudent(student, updateStudentDto.GroupIds);
        }
        return Ok();
    }



}
