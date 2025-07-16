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

        if (studentPaymentSycle.StudentPayments.Count == 0)
        {

            return _pendingStatus;

        }

        



        return string.Empty;

    }

}
