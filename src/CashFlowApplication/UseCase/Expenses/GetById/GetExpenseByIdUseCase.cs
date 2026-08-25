using AutoMapper;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCase.Expenses.GetById;

public class GetExpenseByIdUseCase : IExpenseByIdUseCase
{
    private readonly IExpenseReadOnlyRepository _repoisitory;
    private readonly IMapper _mapper;

    public GetExpenseByIdUseCase(IExpenseReadOnlyRepository repository, IMapper mapper)
    {
        _repoisitory = repository;
        _mapper = mapper;
    }

    public async Task<ResponseExpensesById> Execute(long id)
    {
        var result = await _repoisitory.GetById(id);

        if (result == null)
        {
            throw new NotFoundException(ResourceErroMessage.EXPENSE_NOT_FOUND);
        }

        return _mapper.Map<ResponseExpensesById>(result);
    }


}
