using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;
[Table("users")]
public class User
{
    [Column("id")]
    public int Id { get; set; }
    [Column("full_name")]

    public required string FullName { get; set; }

    [Column("username")]
    public required string Username { get; set; }

    [Column("password")]
    public required string Password { get; set; }
    [Column("role_id")]
    public int? RoleId { get; set; }
    public Role Role { get; set; }

}
