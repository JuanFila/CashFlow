using AutoMapper;
using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Response;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlowApplication.UseCase.Expenses.Register;

public class RegisterExpensesUseCase : IRegisterExpensesUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterExpensesUseCase(
        IExpensesRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisterExpenses> Execute(RequestExpense request)
    {   
        Validate(request);

        var entity = _mapper.Map<Expense>(request);

        await _repository.Add(entity);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisterExpenses>(entity);
    }

    private void Validate(RequestExpense request)
    {
        var validator = new RegisterExpenseValidator();

        var result = validator.Validate(request);
        
        if(!result.IsValid)
        {
            var erroMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(erroMessages);
        }
    }
}
