
namespace EduCenterApi.Application.DTOs.GroupDto;

public class UpdateGroupDto
{


    public string? Name { get; set; }
    public int? TeacherId { get; set; }

    public int? SinceId { get; set; }

    public int? TeacherPortion { get; set; }

    public int? Price { get; set; }

    public DateOnly? BeginDate { get; set; }

}
