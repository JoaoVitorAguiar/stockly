using Stockly.Core.Services;

namespace Stockly.Infra.Services;

public class BCryptHashService : IHashService
{
    private const int WorkFactor = 6;

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}