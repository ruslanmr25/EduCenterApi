

using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.Abstractions.IRepositories;

public interface IGroupRepository:IBaseRepository<Group>
{

    public Task<PagedResult<Group>> GetAllByCenterIdAsync(int centerId, int page, int pageSize);

}
