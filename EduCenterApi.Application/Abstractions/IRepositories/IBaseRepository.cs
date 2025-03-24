namespace EduCenterApi.Application.Abstractions.IRepositories;

public interface IBaseRepository<T>
{
    public  Task<List<T>> All();
    public Task<T?> Find(int id);

    public Task Create(T entity);

    public Task Update(int id,T entity);
    public Task Delete(int id);

}
