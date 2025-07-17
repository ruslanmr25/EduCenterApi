using System.ComponentModel.DataAnnotations;

namespace EduCenterApi.Application.DTOs.StudentPaymentDto;

public class CreateStudentPaymentDto
{
    public int Amount { get; set; }

    [Required]
    public int Payed { get; set; }

    [Required]
    public int StudentPaymentSycleId { get; set; }

    [Required]
    public DateOnly PaidDate { get; set; }
}
