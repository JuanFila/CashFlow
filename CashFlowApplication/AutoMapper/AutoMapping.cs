using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Response;
using CashFlow.Domain.Entity;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestExpense, Expense>();
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisterExpenses>();
    }
}
