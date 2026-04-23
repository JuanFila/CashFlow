using CashFlow.Domain.Entity;
using CashFlow.Domain.Repositories.Expenses;
using CashflowInfraestructure.DataAccess;

namespace CashflowInfraestructure.Repositories;

internal class ExpenseRepository : IExpensesRepository
{
    private readonly CashFlowDbContext _dbContext;

    public ExpenseRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }
}

