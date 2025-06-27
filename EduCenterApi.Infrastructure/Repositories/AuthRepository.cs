using System;
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
     protected readonly BaseContext _context;

     public AuthRepository(BaseContext baseContext)
     {
          _context = baseContext;
     }

     public async Task<User?> Me(int id)
     {
          return await _context.Users.Where(u => u.Id == id).Include(u => u.Role).Include(u => u.Center).Include(u => u.TeacherCenters).FirstOrDefaultAsync();
     }
}
