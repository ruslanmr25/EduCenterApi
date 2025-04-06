
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;

public class Student
{

    [Column("id")]
    public int Id { get; set; }
    [Column("full_name")]

    public required string FullName { get; set; }

    [Column("phone")]
    public required string Phone { get; set; }

    [Column("father_phone")]
    public string? FatherPhone { get; set; }
    [Column("mother_phone")]
    public string? MotherPhone { get; set; }


    public List<Group> Groups { get; set; }

    public List<StudentPaymentSycle> StudentPaymentSycles { get;  set; }


}
