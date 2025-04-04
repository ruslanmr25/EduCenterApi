
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Application.DTOs.GroupDto;

public class UpdateGroupDto
{


    public string? Name { get; set; }
    public int? TeacherId { get; set; }

    public int? SinceId { get; set; }

    public int? TeacherPortion { get; set; }

    public int? Price { get; set; }

    public DateOnly? BeginDate { get; set; }


    public List<DayOfWeek> Days { get; set; }

    public DateOnly EndDate { get; set; }

    public List<TimeOnly> Times { get; set; }




}
