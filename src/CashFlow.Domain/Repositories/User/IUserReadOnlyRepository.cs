namespace CashFlow.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmail(string email);
    Task<Entity.User?> GetUserByEmail(string email);
}
