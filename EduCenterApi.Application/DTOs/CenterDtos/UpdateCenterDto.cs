using System.ComponentModel.DataAnnotations;

namespace EduCenterApi.Application.DTOs.CenterDtos;

public class UpdateCenterDto
{

    [StringLength(100,MinimumLength =1)]
    public string? Name { get; set; }

    
    public int? AdminId { get; set; }

}
