
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories;
public class StudentPaymentRepository : BaseRepository<StudentPayment>, IStudentPaymentRepository
{
    public StudentPaymentRepository(BaseContext baseContext) : base(baseContext) { }

   

  
    
}
