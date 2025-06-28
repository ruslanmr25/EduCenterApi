using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    [JsonIgnore]

    public Role Role { get; set; }


    [JsonIgnore]
    public List<TeacherCenter> TeacherCenters { get; set; }
    [JsonIgnore]

    public Center? Center { get; set; }

}
