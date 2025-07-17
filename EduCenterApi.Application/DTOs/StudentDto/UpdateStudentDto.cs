namespace EduCenterApi.Application.DTOs.StudentDto;

public class UpdateStudentDto
{


    public string? FullName { get; set; }

    public string? Phone { get; set; }


    public string? FatherPhone { get; set; }

    public string? MotherPhone { get; set; }


    public List<int>? GroupIds { get; set; }
}
