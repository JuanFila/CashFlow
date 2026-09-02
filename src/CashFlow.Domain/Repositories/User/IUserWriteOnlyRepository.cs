namespace CashFlow.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    Task Add(Entity.User user);
}
