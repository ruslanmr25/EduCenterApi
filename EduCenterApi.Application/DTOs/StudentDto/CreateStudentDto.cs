
using System.ComponentModel.DataAnnotations.Schema;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.DTOs.StudentDto;

public class CreateStudentDto
{


    public required string FullName { get; set; }

    public required string Phone { get; set; }

  
    public string? FatherPhone { get; set; }
   
    public string? MotherPhone { get; set; }


    public List<int> GroupIds { get; set; }
}
