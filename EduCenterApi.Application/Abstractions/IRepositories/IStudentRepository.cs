
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.Abstractions.IRepositories;

public interface IStudentRepository : IBaseRepository<Student>
{

    public Task<PagedResult<Student>> GetAllByCenter(int CenterId, int? GroupId = null, int page = 1, int pageSize = 40);

    public Task AttachStudent(Student student, List<int> groups);



}
