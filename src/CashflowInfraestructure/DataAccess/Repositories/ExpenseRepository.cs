using CashFlow.Domain.Entity;
using CashFlow.Domain.Repositories.Expenses;
using CashflowInfraestructure.DataAccess;

namespace CashflowInfraestructure.Repositories;

internal class ExpenseRepository : IExpensesRepository
{
    public void Add(Expense expense)
    {
        var dbContext = new CashFlowDbContext();

        dbContext.Expenses.Add(expense);

        dbContext.SaveChanges();
    }
}

