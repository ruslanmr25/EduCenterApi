using BCrypt.Net;
using EduCenterApi.Application.Abstractions.Hasher;

namespace EduCenterApi.Application.PasswordHashing;

public class PasswordHasher:IPasswordHasher
{

    public string Hashing(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password,string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
