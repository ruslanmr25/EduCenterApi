using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;

[Table("roles")]
public class Role
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; }
}
