using CashFlow.Domain.Repositories.Expenses;
using CashflowInfraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashflowInfraestructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IExpensesRepository, ExpenseRepository>();
    }
}
