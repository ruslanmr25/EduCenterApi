using EduCenterApi.Application.Abstractions.IValidators;
using System.ComponentModel.DataAnnotations;

namespace EduCenterApi.Application.Attributes;

public class UniqueAttribute : ValidationAttribute
{
    private readonly string _columnName;
    private readonly string _tableName;




    public UniqueAttribute(string columnName, string tableName)
    {
        _columnName = columnName ?? throw new ArgumentNullException(nameof(columnName));
        _tableName = tableName;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        var uniqueValidator = validationContext.GetService(typeof(IUniqueValidator)) as IUniqueValidator;

        if (uniqueValidator == null)
        {

            throw new InvalidOperationException("IUserService is not available.");
        }


        if (value == null)
        {
            return new ValidationResult("Foydalanuvchi nomi bo'sh bo'lishi mumkin emas.");
        }

        var count = uniqueValidator.Validate(value, _columnName, _tableName);



        return count > 0 ? new ValidationResult($" `{value}` allaqachon mavjud.") : ValidationResult.Success;
    }

}
