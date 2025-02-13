namespace PortfolioApp.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(int userId)
    {
        public static GetUserByIdQuery With(int userId)
        {
            return new(userId);
        }
    }
}
