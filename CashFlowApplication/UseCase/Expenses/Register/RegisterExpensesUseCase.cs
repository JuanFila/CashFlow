using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Response;
using CashFlow.Exception.ExceptionBase;

namespace CashFlowApplication.UseCase.Expenses.Register;

public class RegisterExpensesUseCase
{
    public ResponseRegisterExpenses Execute(RequestExpense request)
    {   
        Validate(request);

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
