using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.Abstractions.IRepositories;

public interface IStudentPaymentSycleRepository:IBaseRepository<StudentPaymentSycle>
{
    public Task AddStudentPaymentSycleAsync(int studentId, int groupId, int amount, DateOnly beginDate, DateOnly nextDate);
    public Task UpdateSycleAsync(int studentId, List<int> groupIds);

}
