using CashFlow.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CashflowInfraestructure.DataAccess;

public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;database=cashflowdb;user=root;password=root";
        var version = new Version(8, 0, 26);
        var serverVersion = new MySqlServerVersion(version);

        optionsBuilder.UseMySql(
            connectionString,
            serverVersion
        );
    }
}
