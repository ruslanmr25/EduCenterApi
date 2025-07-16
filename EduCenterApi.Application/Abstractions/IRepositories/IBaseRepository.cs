using EduCenterApi.Application.Pagination;

namespace EduCenterApi.Application.Abstractions.IRepositories;


public interface IBaseRepository<T> where T : class
{
    public Task<PagedResult<T>> GetAllAsync(int page, int pageSize);

    public Task<T?> GetByIdAsync(int id);
    public Task AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(int id);
}

