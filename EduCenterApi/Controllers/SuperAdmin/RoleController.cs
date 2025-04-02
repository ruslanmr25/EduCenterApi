using EduCenterApi.Application.Abstractions.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.SuperAdmin;

[Route("api/super-admin/roles")]
[ApiController]
public class RoleController : ControllerBase
{

    protected readonly IRoleRepository _roleRepository;

    public RoleController(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {

        return Ok(await _roleRepository.GetAllAsync(1, 100));

    }
}
