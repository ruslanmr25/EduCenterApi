using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterApi.Domain.Entities;

[Table("student_monthly_payment")]
public class StudentMonthlyPayment
{
    [Column("id")]
    public int Id { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [Column("month")]
    public string Month { get; set; }

    [Column("is_completed")]
    public int Payed { get; set; }

    public StudentPaymentSycle StudentPaymentSycle { get; set; }

    [Column("student_payment_sycle_id")]
    public int StudentPaymentSycleId { get; set; }
}
