
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.DTOs.CenterDtos;

public class CreateCenterDto
{

    public int Id { get; set; }
    public string? Name { get; set; }
    public int AdminId { get; set; }


}
