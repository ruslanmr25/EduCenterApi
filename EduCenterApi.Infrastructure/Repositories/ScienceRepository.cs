using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;

namespace EduCenterApi.Infrastructure.Repositories;

public class ScienceRepository : BaseRepository<Since>, IScienceRepository
{
    public ScienceRepository(BaseContext baseContext) : base(baseContext)
    {
    }
}
