using CashflowInfraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Domain.Repositories.User;

internal class UserRepository : IUserReadOnlyRepository
{
    private readonly CashFlowDbContext _dbcontext;
    public UserRepository(CashFlowDbContext dbcontext) => _dbcontext = dbcontext;
        
    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
       return await _dbcontext.Users.AnyAsync(user => user.Email.Equals(email));
    }
}
