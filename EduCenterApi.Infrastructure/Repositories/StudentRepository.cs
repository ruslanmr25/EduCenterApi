using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.Pagination;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(BaseContext context)
        : base(context) { }

    //public async Task<Student> AddAsync(Student student)
    //{

    // await _context.Set<Student>().AddAsync(student);

    //    await _context.SaveChangesAsync();

    //}

    public async Task<PagedResult<Student>> GetAllByCenter(
        int CenterId,
        int? GroupId = null,
        int page = 1,
        int pageSize = 40
    )
    {
        var query = _context
            .Set<Student>()
            .AsQueryable()
            .Include(s => s.Groups)
            .Where(x => x.Groups.Any(g => g.CenterId == CenterId));

        if (GroupId != null)
        {
            query = query.Where(x => x.Groups.Any(g => g.Id == GroupId));
        }

        var totalCount = await query.CountAsync();
        var result = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResult<Student>(result, totalCount, page, pageSize);
    }

    public override async Task<Student?> GetByIdAsync(int id)
    {
        return await _context
            .Students.Where(student => student.Id == id)
            .Include(student => student.StudentPaymentSycles)
            .ThenInclude(sycle => sycle.StudentMonthlyPayment)
            .FirstOrDefaultAsync();
    }

    public async Task AttachStudent(Student student, List<int> groupIds)
    {
        var existingStudent = await _context
            .Set<Student>()
            .Include(s => s.Groups)
            .FirstOrDefaultAsync(s => s.Id == student.Id);

        if (existingStudent == null)
            throw new Exception("Student not found");

        var newGroups = await _context
            .Set<Group>()
            .Where(g => groupIds.Contains(g.Id))
            .ToListAsync();

        existingStudent.Groups.Clear();

        foreach (var group in newGroups)
        {
            existingStudent.Groups.Add(group);
        }

        await _context.SaveChangesAsync();
    }
}
