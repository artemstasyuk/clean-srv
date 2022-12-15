using CatStore.Domain.UserAggregate;

namespace CatStore.Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
   string GenerateToken(User user);
}