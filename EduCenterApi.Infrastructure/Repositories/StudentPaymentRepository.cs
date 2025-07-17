using System;
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories;

public class StudentPaymentRepository : IStudentPaymentRepository
{
    protected readonly BaseContext _context;

    public StudentPaymentRepository(BaseContext baseContext)
    {
        _context = baseContext;
    }

    public async Task AddPayment(StudentPayment payment)
    {
        await _context.StudentPayments.AddAsync(payment);
    }

    public async Task<StudentPaymentSycle?> GetPaymentSycle(int sycleId)
    {
        return await _context
            .StudentPaymentSycles.Where(s => s.Id == sycleId)
            .Include(s => s.StudentPayments)
            .FirstOrDefaultAsync();
    }
}
