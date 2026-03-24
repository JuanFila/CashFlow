using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestExpenseBuilder
{
    public static RequestExpense Build()
    {
     return new Faker<RequestExpense>()
            .RuleFor(r => r.Title, faker => faker.Commerce.Product())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.Paymentype, faker => faker.PickRandom<PaymenteType>())
            .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
    }
}
