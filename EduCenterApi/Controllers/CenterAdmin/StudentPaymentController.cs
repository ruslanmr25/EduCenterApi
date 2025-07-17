using EduCenterApi.Application.Abstractions.IRepositories;
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

        [HttpGet("sycles/{sycleId}")]
        public async Task<IActionResult> GetStudentPaymentSycle(int sycleId)
        {
            var sycle = await _studentPaymentRepository.GetPaymentSycleAsync(sycleId);

            if (sycle is null)
            {
                return NotFound();
            }

            return Ok(sycle);
        }

        [HttpGet("students/{studentId}")]
        public async Task<IActionResult> GetStudentPaymentSycles(int studentId)
        {
            var sycle = await _studentPaymentRepository.GetStudentPaymentSyclesAsync(studentId);

            if (sycle is null)
            {
                return NotFound();
            }

            return Ok(sycle);
        }
    }
}
