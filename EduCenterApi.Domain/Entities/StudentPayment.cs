using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;
[Table("student_payments")]
public class StudentPayment
{

    [Column("id")]
    public int Id { get; set; }

    [Column("amount")]
    public int Amount { get; set; }
    [Column("payed")]

    public int Payed { get; set; }

    public StudentPaymentSycle StudentPaymentSycle { get; set; }
    [Column("student_payment_sycle_id")]

    public int StudentPaymentSycleId { get; set; }
    [Column("paid_date")]

    public DateOnly PaidDate { get; set; }

}
