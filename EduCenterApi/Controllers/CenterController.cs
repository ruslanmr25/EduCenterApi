using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.DTOs.CenterDtos;
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers;

[Route("api/centers")]
[ApiController]
public class CenterController : ControllerBase
{
    private readonly ICenterRepository _centerRepository;

    public CenterController(ICenterRepository centerRepository)
    {
        _centerRepository = centerRepository;
    }

    // GET: api/Center
    [HttpGet]
    public async Task<ActionResult<PagedResult<Center>>> Index()
    {
        return await _centerRepository.GetAllAsync(1, 40);
    }

    // GET: api/Center/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Center?>> Show(int id)
    {
        return await _centerRepository.GetByIdAsync(id);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutCenter(int id, Center center)
    {


        return NoContent();
    }

    // POST: api/Center
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<IActionResult> Create(CreateCenterDto centerDto)
    {

        Center center = new Center
        {
            Name = centerDto.Name,
            AdminId = centerDto.AdminId
        };
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
