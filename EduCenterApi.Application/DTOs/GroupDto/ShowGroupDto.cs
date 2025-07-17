using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.DTOs.GroupDto;

public class ShowGroupDto
{

    public int Id { get; set; }



    public required string Name { get; set; }


    public int TeacherId { get; set; }
    public User Teacher { get; set; }





    public int CenterId { get; set; }
    public Center Center { get; set; }



    public int SinceId { get; set; }
    public Since Since { get; set; }



    public int TeacherPortion { get; set; }


    public int Price { get; set; }

    public DateOnly BeginDate { get; set; }

    public bool IsCompleted { get; set; } = false;

    public List<DayOfWeek> Days { get; set; }


    public DateOnly EndDate { get; set; }

    public List<TimeOnly> Times { get; set; }



    public List<Student> Students { get; set; }


    public List<StudentPaymentSycle> StudentPaymentSycles { get; set; }










}
