using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;


[Table("student_payment_sycle")]
public class StudentPaymentSycle
{
    [Column("id")]
    public int Id { get; set; }


    public Student Student { get; set; }

    
    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [Column("status")]
    public string Status { get; set; } = "active";

    [Column("sycle_begin_date")]
    public DateOnly SycleBeginDate { get; set; }

    [Column("sycle_end_date")]
    public DateOnly? SycleEndDate { get; set; }

    [Column("sycle_next_date")]
    public DateOnly SycleNexDate { get; set; }

    public Group Group { get; set; }

    [Column("group_id")]
    public int GroupId { get; set; }

    public List<StudentPayment> StudentPayments { get; set; }


}
