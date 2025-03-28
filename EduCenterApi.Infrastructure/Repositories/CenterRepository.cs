
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;

namespace EduCenterApi.Infrastructure.Repositories;

public class CenterRepository :BaseRepository<Center>, ICenterRepository
{
    public CenterRepository(BaseContext baseContext) : base(baseContext)
    {
    }

}