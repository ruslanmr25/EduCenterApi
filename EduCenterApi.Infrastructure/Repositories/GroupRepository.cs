using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories;

public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    public GroupRepository(BaseContext baseContext) : base(baseContext)
    {
    }

    public override async Task<PagedResult<Group>> GetAllAsync(int page, int pageSize)
    {
        var query = _context.Set<Group>().AsQueryable().Include(g=>g.Teacher);
        var totalCount = await query.CountAsync();

        var result = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResult<Group>(result, totalCount, page, pageSize);

    }



    public async Task<PagedResult<Group>> GetAllByCenterIdAsync(int centerId, int page, int pageSize)
    {
        var query = _context.Set<Group>().AsQueryable();
        query = query.Where(x => x.CenterId == centerId);
        var totalCount = await query.CountAsync();
        var result = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResult<Group>(result, totalCount, page, pageSize);
    }
}
