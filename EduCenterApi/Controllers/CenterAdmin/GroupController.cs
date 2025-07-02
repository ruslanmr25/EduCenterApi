using AutoMapper;
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.DTOs.GroupDto;
using Microsoft.AspNetCore.Mvc;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Controllers.CenterAdmin;

[Route("api/center-admin/groups")]
[ApiController]
public class GroupController : ControllerBase
{

    protected int CenterId = 4;

    protected readonly IMapper _mapper;


    protected readonly IGroupRepository _groupRepository;

    public GroupController(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }



    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 40)
    {
        return Ok(await _groupRepository.GetAllByCenterIdAsync(CenterId, page, pageSize));
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateGroupDto groupDto)
    {
        var group = _mapper.Map<Group>(groupDto);

        group.CenterId = CenterId;

        await _groupRepository.AddAsync(group);


        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Show(int id)
    {
        Group? group = await _groupRepository.GetByIdAsync(id);
        if (group == null)
        {
            return NotFound();
        }

        return Ok(group);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateGroupDto groupDto)
    {

        Group? group = await _groupRepository.GetByIdAsync(id);
        if (group == null)
        {
            return NotFound();
        }

        _mapper.Map(groupDto, group);

        await _groupRepository.UpdateAsync(group);


        return Ok();
    }
    
      [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _groupRepository.DeleteAsync(id);

            return Ok();
        }

}
