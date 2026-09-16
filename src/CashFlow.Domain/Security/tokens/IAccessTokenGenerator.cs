using CashFlow.Domain.Entity;

namespace CashFlow.Domain.Security.tokens;

public interface IAccessTokenGenerator
{
    string Generator(User user);
}
