using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;

[Table("centers")]
public class Center
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }
    [Column("admin_id")]
    public int AdminId { get; set; }
    public  User Admin { get; set; }


    public virtual List<TeacherCenter> TeacherCenters { get; set; }


}
