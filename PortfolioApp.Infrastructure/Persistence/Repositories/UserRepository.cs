using Microsoft.EntityFrameworkCore;
using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Task<bool> IsNameAndAuthorAlreadyExist(string email, string author)
        {
            var matches = _context.Users.
                Any(a => a.Email.Equals(email));

            return Task.FromResult(matches);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.Include(p => p.Role).FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<User> GetUserByEmailAsync(string userEmail)
        {
            return await _context.Users.Include(p => p.Role).FirstOrDefaultAsync(x => x.Email == userEmail);
        }
    }
}
