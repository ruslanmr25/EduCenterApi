
using EduCenterApi.Application.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EduCenterApi.Application.DTOs.TeacherDto;

public class CreateTeacherDto
{

    [Required(ErrorMessage = "To'liq ism talab qiladi")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 100 characters.")]
    public required string FullName { get; set; }

    [Required(ErrorMessage = "Username talab qiladi")]
    [Unique("username", "users")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "Parol talab qiladi")]
    [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
    //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
    //    ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
    public required string Password { get; set; }

    
}
