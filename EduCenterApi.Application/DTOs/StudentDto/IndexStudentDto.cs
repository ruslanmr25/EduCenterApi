using System;
using System.Text.RegularExpressions;

namespace EduCenterApi.Application.DTOs.StudentDto;

public class IndexStudentDto
{

     public int Id { get; set; }

     public required string FullName { get; set; }


     public required string Phone { get; set; }

     public string? FatherPhone { get; set; }

     public string? MotherPhone { get; set; }



     public required List<string> Groups { get; set; }


}
