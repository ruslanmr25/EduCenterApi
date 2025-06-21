using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduCenterApi.Controllers.CenterAdmin;

[Route("api/[controller]")]
[ApiController]
public class StudentPaymentController : ControllerBase
{

    protected readonly IStudentPaymentRepository _studentPaymentRepository;
    protected readonly IStudentPaymentSycleRepository _studentPaymentSycleRepository;

    public StudentPaymentController(IStudentPaymentRepository studentPaymentRepository, IStudentPaymentSycleRepository studentPaymentSycleRepository)
    {
        _studentPaymentRepository = studentPaymentRepository;
        _studentPaymentSycleRepository = studentPaymentSycleRepository;
    }

    [HttpPost]

    public async Task<IActionResult> Pay(int sycleId , int paid)
    {
        StudentPaymentSycle? sycle = await _studentPaymentSycleRepository.GetByIdAsync(sycleId);

        if (sycle == null)
            return NotFound();



        StudentPayment payment = new StudentPayment()
        {
            Amount=sycle.Amount,
            PaidDate=DateOnly.FromDateTime(DateTime.Now),
            Payed=paid,
            StudentPaymentSycleId=sycle.Id
        };
        await _studentPaymentRepository.AddAsync(payment);

        if(!sycle.Group.IsCompleted)
        {
            
                sycle.SycleNexDate=sycle.SycleNexDate.AddMonths(1);
      
        }
       await _studentPaymentSycleRepository.UpdateAsync(sycle);


        return Ok();
    }
}
