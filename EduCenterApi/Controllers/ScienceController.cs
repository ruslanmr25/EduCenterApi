using EduCenterApi.Application.Abstractions.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScienceController : ControllerBase
{
    protected readonly IScienceRepository _scienceRepository;

    public ScienceController(IScienceRepository scienceRepository)
    {
        _scienceRepository = scienceRepository;
    }

  

    [HttpGet]
    public async Task<IActionResult> Index(int page=1,int pageSize=40)
    {


        return Ok(await _scienceRepository.GetAllAsync(page, pageSize));


    }
    [HttpPost]
    public async Task<IActionResult> Create()
    {

        return Ok();
    }


}
