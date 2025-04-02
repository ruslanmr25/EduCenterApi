namespace EduCenterApi.Application.Abstractions.IValidators;

public interface IUniqueValidator
{

    public int Validate(object value, string columnName, string tableName);
}
