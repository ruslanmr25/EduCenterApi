using EduCenterApi.Application.Abstractions.IValidators;
using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EduCenterApi.Infrastructure.Validators;

public class UniqueValidator : IUniqueValidator
{
    protected readonly BaseContext _context;

    public UniqueValidator(BaseContext context)
    {
        _context = context;
    }

    public int Validate(object value, string columnName, string tableName)
    {
        if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(columnName))
        {
            throw new InvalidOperationException("Jadval yoki ustun topilmadi.");
        }

        var query = $"SELECT COUNT(1) AS \"Value\" FROM \"{tableName}\" WHERE \"{columnName}\" = @p0";

        int count = _context.Database
            .SqlQueryRaw<int>(query, value)
            .FirstOrDefault();

        return count;
    }

}
