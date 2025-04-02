using AutoMapper;
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.DTOs.CenterDtos;
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.SuperAdmin;

[Route("api/super-admin/centers")]
[ApiController]
public class CenterController : ControllerBase
{
    private readonly ICenterRepository _centerRepository;
    private readonly IMapper _mapper;

    public CenterController(ICenterRepository centerRepository, IMapper mapper)
    {
        _centerRepository = centerRepository;
        _mapper = mapper;
    }

    // GET: api/Center
    [HttpGet]
    public async Task<ActionResult<PagedResult<Center>>> Index(int page = 1, int pageSize = 40)
    {
        return await _centerRepository.GetAllAsync(page, pageSize);
    }

    // GET: api/Center/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Center?>> Show(int id)
    {
        return await _centerRepository.GetByIdAsync(id);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutCenter(int id, UpdateCenterDto centerDto)
    {
        Center? center = await _centerRepository.GetByIdAsync(id);

        if (center == null)
        {
            return NotFound();
        }

        _mapper.Map(centerDto, center);

        await _centerRepository.UpdateAsync(center);

        return Ok();
    }

    // POST: api/Center
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<IActionResult> Create(CreateCenterDto centerDto)
    {
        //check that only admin role can be added into dto
        Center center = _mapper.Map<Center>(centerDto);
        await _centerRepository.AddAsync(center);

        return NoContent();


    }

    // DELETE: api/Center/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCenter(int id)
    {
        await _centerRepository.DeleteAsync(id);
        return NoContent();
    }

}
