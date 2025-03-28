
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.Pagination;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{

    protected readonly BaseContext _context;

    public BaseRepository(BaseContext baseContext)
    {
        _context = baseContext;
    }

    public async Task<PagedResult<T>> GetAllAsync(int page, int pageSize)
    {
        var query = _context.Set<T>().AsQueryable();
        var totalCount = await query.CountAsync();

        var result = await query.Take(pageSize).ToListAsync();

        return new PagedResult<T>(result, totalCount, page, pageSize);

    }



    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);

        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(int id)
    {
        var entity = await this.GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }


    public async ValueTask<T?> GetByIdAsync(int id)
    {
        T? entity = await _context.Set<T>().FindAsync(id);

        return entity;

    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

}
