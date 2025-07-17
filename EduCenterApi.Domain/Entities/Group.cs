using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;


[Table("groups")]
public class Group
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }
    [Column("teacher_id")]
    public int TeacherId { get; set; }
    public User Teacher { get; set; }



    [Column("center_id")]
    public int CenterId { get; set; }
    public Center Center { get; set; }

    [Column("since_id")]
    public int SinceId { get; set; }
    public Since Since { get; set; }

    [Column("teacher_portion")]
    public int TeacherPortion { get; set; }


    [Column("price")]
    public int Price { get; set; }

    [Column("begin_date")]
    public DateOnly BeginDate { get; set; }

    [Column("is_completed")]
    public bool IsCompleted { get; set; } = false;

    public List<DayOfWeek> Days { get; set; }


    [Column("end_date")]
    public DateOnly EndDate { get; set; }

    [Column("times")]
    public List<TimeOnly> Times { get; set; }



    public List<Student> Students { get; set; }


    public List<StudentPaymentSycle> StudentPaymentSycles { get; set; }




}
