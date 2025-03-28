
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;

namespace EduCenterApi.Infrastructure.Repositories;
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        public UserRepository(BaseContext baseContext) : base(baseContext)
        {
    }
}
