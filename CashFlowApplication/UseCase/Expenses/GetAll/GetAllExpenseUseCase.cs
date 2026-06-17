using AutoMapper;
using CashFlow.Communication.Response;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCase.Expenses.GetAll;

public class GetAllExpenseUseCase : IGetAllExpensesUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;
    public GetAllExpenseUseCase(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseExpenses> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseExpenses
        {
            Expenses = _mapper.Map<List<ResponseShortExpense>>(result)
        };
    }
}
