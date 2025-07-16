using AutoMapper;
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.DTOs.ScienceDto;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.CenterAdmin;

[Route("api/center-admin/sciences")]
[ApiController]
public class ScienceController : ControllerBase
{


    protected int CenterId = 5;

    protected readonly IScienceRepository _scienceRepository;

    protected readonly IMapper _mapper;

    public ScienceController(IScienceRepository scienceRepository, IMapper mapper)
    {
        //Writre middle to only admin change own center science
        //and other admins cannot change others science
        _scienceRepository = scienceRepository;
        _mapper = mapper;
    }



    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 40)
    {
        return Ok(await _scienceRepository.GetAllCenterScienceAsync(CenterId, page, pageSize));
    }


    [HttpGet("{id}/groups")]
    public async Task<IActionResult> GetGroupByScience(int id)
    {

        var sinces = await _scienceRepository.GetAllGroupByScienceAsync(CenterId, id);

        // sinces.Items.
        return Ok(sinces);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateScienceDto scienceDto)
    {


       
        var science = _mapper.Map<Since>(scienceDto);

        science.CenterId = CenterId;
        await _scienceRepository.AddAsync(science);

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateScienceDto scienceDto)
    {


        var science = await _scienceRepository.GetByIdAsync(id);
        if (science == null)
        {
            return NotFound();
        }
        _mapper.Map(scienceDto, science);
        await _scienceRepository.UpdateAsync(science);
        return Ok();
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Show(int id)
    {
        Since? science = await _scienceRepository.GetByIdAsync(id);
        if (science == null)
        {
            return NotFound();
        }

        return Ok(science);
    }


    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete(int id)
    {
        await _scienceRepository.DeleteAsync(id);

        return Ok();
    }



}
