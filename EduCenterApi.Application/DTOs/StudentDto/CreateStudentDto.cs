using System.ComponentModel.DataAnnotations;

namespace EduCenterApi.Application.DTOs.StudentDto;

public class CreateStudentDto
{
    [Required(ErrorMessage = "Ism Familiya kiritilmagan")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefon raqam kiritilmagan")]
    public string Phone { get; set; } = string.Empty;

    public string? FatherPhone { get; set; }

    public string? MotherPhone { get; set; }

    [MinLength(1, ErrorMessage = "Kamida bitta guruh tanlanishi kerak")]
    public List<int> GroupIds { get; set; } = new();

    public DateOnly? BeginSycleDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}
