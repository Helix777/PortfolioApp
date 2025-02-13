using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Common.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByIdAsync(int userId);

        Task<User> GetUserByEmailAsync(string userEmail);
    }
}
