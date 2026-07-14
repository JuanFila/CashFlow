using AutoMapper;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCase.Expenses.GetById;

public class GetExpenseByIdUseCase : IExpenseByIdUseCase
{
    private readonly IExpensesRepository _repoisitory;
    private readonly IMapper _mapper;

    public GetExpenseByIdUseCase(IExpensesRepository repository, IMapper mapper)
    {
        _repoisitory = repository;
        _mapper = mapper;
    }

    public async Task<ResponseExpensesById> Execute(long id)
    {
        var result = await _repoisitory.GetById(id);

        return _mapper.Map<ResponseExpensesById>(result);
    }


}
