using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories;

public class ScienceRepository : BaseRepository<Since>, IScienceRepository
{
    public ScienceRepository(BaseContext baseContext) : base(baseContext)
    {
    }



    public async Task<PagedResult<Since>> GetAllCenterScienceAsync(int centerId, int page, int pageSize)
    {
        var query = _context.Set<Since>().AsQueryable();
        query = query.Where(s => s.CenterId == centerId);

        var totalCount = await query.CountAsync();
        var result = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResult<Since>(result, totalCount, page, pageSize);
    }
}
