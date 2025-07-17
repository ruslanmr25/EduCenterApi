using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.Abstractions.IRepositories;

public interface IStudentPaymentRepository
{
    public Task<StudentPaymentSycle?> GetPaymentSycleAsync(int sycleId);
    public Task<List<StudentPaymentSycle>> GetStudentPaymentSyclesAsync(int studentId);

    public Task AddPaymentAsync(StudentPayment payment);
}
