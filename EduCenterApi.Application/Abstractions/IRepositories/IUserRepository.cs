
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.Abstractions.IRepositories;

public interface IUserRepository : IBaseRepository<User>
{

    public Task<PagedResult<User>> GetAllTeacherAsync(int centerId,int page, int pageSize);

}
