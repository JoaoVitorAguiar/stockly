using Stockly.Core.Entities;

namespace Stockly.Core.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
