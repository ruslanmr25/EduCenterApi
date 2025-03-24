using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;


[Table("sinces")]
public class Since
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }
    [Column("center_id")]
    public int CenterId { get; set; }
    public Center Center { get; set; }
}
