
using EduCenterApi.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Application.DTOs.ScienceDto;

public class CreateScienceDto
{

    public required string Name { get; set; }
 
}
