using CashFlow.Domain.Entity;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpenseReadOnlyRepository
{
    Task<List<Expense>> GetAll();

    Task<Expense?> GetById(long id);

    Task<List<Expense>> GetByMonth(DateOnly month);
}
