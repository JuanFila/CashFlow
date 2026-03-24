using CashFlowApplication.UseCase.Expenses.Register;
using CommonTestUtilities.Requests;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatorTest
{
    [Fact]
    public void Success()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestExpenseBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert
        Assert.True(result.IsValid);
    }


    [Fact]
    public void ErrorTitleEmpty()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestExpenseBuilder.Build();
        request.Title = string.Empty;

        //Act
        var result = validator.Validate(request);

        //Assert
        Assert.False(result.IsValid);
    }
}
