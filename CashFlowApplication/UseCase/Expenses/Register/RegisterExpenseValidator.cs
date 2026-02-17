using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlowApplication.UseCase.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestExpense>
{
    public RegisterExpenseValidator() 
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ResourceErroMessage.TITLE_REQUIRED)
            .MaximumLength(100).WithMessage(ResourceErroMessage.TITLE_MUST_NOT_THAN);
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage(ResourceErroMessage.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErroMessage.EXPENSES_CANNOT_FOR_THE_FUTURE);
        RuleFor(x => x.Paymentype)
            .IsInEnum().WithMessage(ResourceErroMessage.PAYMENT_TYPE_INVALID);
    }
}
