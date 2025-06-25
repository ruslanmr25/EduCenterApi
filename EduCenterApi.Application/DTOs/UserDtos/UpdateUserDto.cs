
using System.ComponentModel.DataAnnotations;

namespace EduCenterApi.Application.DTOs.UserDtos;

public class UpdateUserDto
{


    [StringLength(100, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 100 characters.")]
    public  string FullName { get; set; }=string.Empty;


    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
    public  string? Username { get; set; }


    [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
    //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
    //    ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
    public  string? Password { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Role id to'g'ri kitilmagan")]
    public int? RoleId { get; set; }
}
