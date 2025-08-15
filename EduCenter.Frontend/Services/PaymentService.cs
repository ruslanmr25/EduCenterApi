using EduCenterApi.Domain.Entities;

namespace EduCenter.Frontend.Services;

public class PaymentService
{
    protected string _completedStatus = "completed";
    protected string _pendingStatus = "pending";
    protected string _expiredStatus = "expired";

    public string GetStatus(Student student)
    {
        StudentPaymentSycle? studentPaymentSycle = student.StudentPaymentSycles.FirstOrDefault();

        ArgumentNullException.ThrowIfNull(studentPaymentSycle);

        if (studentPaymentSycle.StudentMonthlyPayment.Count == 0)
        {
            return _pendingStatus;
        }

        return string.Empty;
    }

    public TimeSpan GetDays(Student student)
    {
        DateOnly now = DateOnly.FromDateTime(DateTime.Now);
        StudentPaymentSycle? studentPaymentSycle = student.StudentPaymentSycles.FirstOrDefault();
        ArgumentNullException.ThrowIfNull(studentPaymentSycle);

        if (studentPaymentSycle.StudentMonthlyPayment.Count == 0)
        {
            DateOnly sycleBeginDate = studentPaymentSycle.SycleBeginDate;

            TimeSpan difference = TimeSpan.FromDays(now.DayNumber - sycleBeginDate.DayNumber);

            Console.WriteLine(difference.TotalDays);
        }

        return new TimeSpan();
    }
}
