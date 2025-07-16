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

    public async Task<PagedResult<Since>> GetAllGroupByScienceAsync(int centerId, int scienceId)
    {
        int page = 1;
        int pageSize = 100;


        var query = _context.Set<Since>().Include(s => s.Groups).AsQueryable();
        query = query.Where(s => s.CenterId == centerId).Where(s => s.Id == centerId);

        var totalCount = await query.CountAsync();
        var result = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResult<Since>(result, totalCount, page, pageSize);

    }


    public override async Task<Since?> GetByIdAsync(int id)
    {
        Since? entity = await _context.Set<Since>().Include(s => s.Groups).Where(s => s.Id == id).FirstOrDefaultAsync();

        return entity;

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
