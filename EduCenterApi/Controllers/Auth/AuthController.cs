using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        protected readonly IAuthRepository _authRepositoy;

        public AuthController(IAuthRepository authRepositoy)
        {
            _authRepositoy = authRepositoy;
        }


        [HttpGet]
        public async Task<IActionResult> Me()
        {
            User? user = await _authRepositoy.Me(2);


            return Ok(user);
        }
    }
}
