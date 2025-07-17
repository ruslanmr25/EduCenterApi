using System.ComponentModel.DataAnnotations;

namespace EduCenterApi.Application.DTOs.ScienceDto;

public class CreateScienceDto
{


    [Required]
    public string Name { get; set; } = string.Empty;

}
