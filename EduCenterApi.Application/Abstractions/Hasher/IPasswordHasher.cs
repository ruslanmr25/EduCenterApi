namespace EduCenterApi.Application.Abstractions.Hasher;

public interface IPasswordHasher
{
    public string Hashing(string password);

    public bool Verify(string password, string hashedPassword);
}
