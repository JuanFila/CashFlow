using CashFlow.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CashflowInfraestructure.DataAccess;

internal class CashFlowDbContext : DbContext
{

    public CashFlowDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Expense> Expenses { get; set; }

}
