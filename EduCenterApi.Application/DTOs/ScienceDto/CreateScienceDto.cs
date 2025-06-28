
using EduCenterApi.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Application.DTOs.ScienceDto;

public class CreateScienceDto
{


    [Required]
    public string Name { get; set; } = string.Empty;
 
}
