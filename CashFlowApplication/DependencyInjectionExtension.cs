using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCase.Expenses.Delete;
using CashFlow.Application.UseCase.Expenses.GetAll;
using CashFlow.Application.UseCase.Expenses.GetById;
using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Application.UseCase.Expenses.Reports.Excel;
using CashFlow.Application.UseCase.Expenses.Reports.Pdf;
using CashFlow.Application.UseCase.Expenses.Update;
using CashFlowApplication.UseCase.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;
namespace CashFlow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpensesUseCase, RegisterExpensesUseCase>();
        services.AddScoped<IGetAllExpensesUseCase, GetAllExpenseUseCase>();
        services.AddScoped<IExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IGenerateExpensesReporExcelUseCase, GenerateExpensesReporExcelUseCase>();
        services.AddScoped<IGenerateExpensesReportPdfUseCase, GenerateExpensesReportPdfUseCase>();

    }
}
