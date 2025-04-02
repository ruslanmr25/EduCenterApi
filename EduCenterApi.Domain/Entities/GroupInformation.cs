using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;


[Table("group_information")]
public class GroupInformation
{
    [Column("id")]
    public int Id { get; set; }

    public Group Group { get; set; }

    [Column("group_id")]
    public int GroupId { get; set; }

    [Column("end_date")]
    public DateOnly EndDate { get; set; }




}
