using CashFlow.Application.UseCase.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Response;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionBase;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Repositories;

namespace CashFlowApplication.UseCase.Expenses.Register;

public class RegisterExpensesUseCase : IRegisterExpensesUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterExpensesUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public ResponseRegisterExpenses Execute(RequestExpense request)
    {   
        Validate(request);

        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            PaymentType = (PaymentType)request.Paymentype,
            Title = request.Title,
        };

        _repository.Add(entity);

        _unitOfWork.Commit();

        return new ResponseRegisterExpenses();
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
