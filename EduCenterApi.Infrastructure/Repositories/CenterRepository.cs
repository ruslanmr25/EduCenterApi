
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories;

public class CenterRepository : BaseRepository<Center>, ICenterRepository
{
    public CenterRepository(BaseContext baseContext) : base(baseContext)
    {
    }


    public override async Task<PagedResult<Center>> GetAllAsync(int page, int pageSize)
    {
        var query = _context.Set<Center>().AsQueryable().Include(c => c.Admin);


        var totalCount = await query.CountAsync();

        var result = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResult<Center>(result, totalCount, page, pageSize);

    }
}