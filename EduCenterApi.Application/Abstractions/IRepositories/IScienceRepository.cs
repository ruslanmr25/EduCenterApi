namespace EduCenterApi.Application.Abstractions.IRepositories;

using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;
public interface IScienceRepository : IBaseRepository<Since>
{



    public Task<PagedResult<Since>> GetAllCenterScienceAsync(int centerId, int page, int pageSize);
    public Task<PagedResult<Since>> GetAllGroupByScienceAsync(int centerId, int scienceId);
    



}
