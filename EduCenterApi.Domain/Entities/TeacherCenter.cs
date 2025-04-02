
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;


[Table("teacher_center")]
public class TeacherCenter
{

    public int Id { get; set; }
    public Center Center { get; set; }

    [Column("center_id")]
    public int CenterId { get; set; }


    public User Teacher { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }
}
