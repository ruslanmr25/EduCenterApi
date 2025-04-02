
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories
{
        public class UserRepository:BaseRepository<User>, IUserRepository
        {
        public UserRepository(BaseContext baseContext) : base(baseContext)
        {



        }


        public async Task<PagedResult<User>> GetAllTeacherAsync(int centerId, int page, int pageSize)
        {
            var query = _context.Set<User>().AsQueryable();

            // Filter users based on the role 'Teacher'
            query = query.Where(x => x.Role.Name == "Teacher");

            query = query.Where(u => u.TeacherCenters.Any(tc => tc.CenterId == centerId));

            var totalCount = await query.CountAsync();
            var result = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<User>(result, totalCount, page, pageSize);
        }


    }
}
