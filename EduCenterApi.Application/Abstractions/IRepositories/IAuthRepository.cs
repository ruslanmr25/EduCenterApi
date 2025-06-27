using System;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.Abstractions.IRepositories;

public interface IAuthRepository
{

     public Task<User?> Me(int id);


}
