
using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Repositories;
public class StudentPaymentSycleRepository : BaseRepository<StudentPaymentSycle>, IStudentPaymentSycleRepository
{
    public StudentPaymentSycleRepository(BaseContext baseContext) : base(baseContext) { }

    public async Task AddStudentPaymentSycleAsync(int studentId, int groupId, int amount, DateOnly beginDate, DateOnly nextDate)
    {
        var studentPaymentSycle = new StudentPaymentSycle
        {
            StudentId = studentId,
            GroupId = groupId,
            Amount = amount,
            SycleBeginDate = beginDate,
            SycleNexDate = nextDate
        };

        await AddAsync(studentPaymentSycle);
    }

    public async Task UpdateSycleAsync(int studentId, List<int> groupIds)
    {
        var currentGroupIds = await _context.Groups
            .Where(g => g.Students.Any(s => s.Id == studentId))
            .Select(g => g.Id)
            .ToListAsync();

        var newGroupIds = groupIds.Except(currentGroupIds).ToList();
        var deletedGroupIds = currentGroupIds.Except(groupIds).ToList();

        // Deactivate old records
        if (deletedGroupIds.Any())
        {
            var now = DateOnly.FromDateTime(DateTime.UtcNow); // UTC tavsiya etiladi
            await _context.StudentPaymentSycles
                .Where(s => s.StudentId == studentId && deletedGroupIds.Contains(s.GroupId))
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(s => s.Status, s => "inactive")
                    .SetProperty(s => s.SycleEndDate, s => now));
        }

        // Add new records
        if (newGroupIds.Any())
        {
            var beginDate = DateOnly.FromDateTime(DateTime.UtcNow);
            var nextDate = beginDate.AddMonths(1);

            var newGroups = await _context.Groups
                .Where(g => newGroupIds.Contains(g.Id))
                .ToListAsync();

            var newCycles = newGroups.Select(g => new StudentPaymentSycle
            {
                StudentId = studentId,
                GroupId = g.Id,
                Amount = g.Price,
                SycleBeginDate = beginDate,
                SycleNexDate = nextDate
            }).ToList();

            await _context.StudentPaymentSycles.AddRangeAsync(newCycles);
            await _context.SaveChangesAsync();
        }
    }
}
