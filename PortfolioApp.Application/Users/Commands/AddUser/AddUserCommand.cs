namespace PortfolioApp.Application.Users.Commands.AddUser
{
    public record AddUserCommand
        (string Email, string Password, string FirstName, string LastName,
        int RoleId)
    {
    }
}
