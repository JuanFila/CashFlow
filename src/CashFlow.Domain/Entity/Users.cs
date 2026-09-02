using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entity;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public Guid UserIdentifier { get; set; }

    public string Role { get; set; } = Roles.TEAM_MEMBER;

    public DateOnly CreateAt { get; set; }
}
