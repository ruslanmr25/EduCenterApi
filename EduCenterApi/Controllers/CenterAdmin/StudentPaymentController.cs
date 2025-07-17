using EduCenterApi.Application.Abstractions.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.CenterAdmin
{
    [Route("api/student-payment")]
    [ApiController]
    public class StudentPaymentController : ControllerBase
    {
        protected readonly IStudentPaymentRepository _studentPaymentRepository;

        public StudentPaymentController(IStudentPaymentRepository studentPaymentRepository)
        {
            _studentPaymentRepository = studentPaymentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentPaymentSycle(int sycleId)
        {
            var sycle = await _studentPaymentRepository.GetPaymentSycle(sycleId);

            if (sycle is null)
            {
                return NotFound();
            }

            return Ok(sycle);
        }
    }
}
