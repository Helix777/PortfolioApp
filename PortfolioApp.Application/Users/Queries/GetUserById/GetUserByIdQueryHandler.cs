using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Application.Common.Interfaces.CQRS;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _usersRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _usersRepository = userRepository;
        }

        public async ValueTask<User> Handle(GetUserByIdQuery query, CancellationToken cancellation)
        {
            return await _usersRepository.GetUserByIdAsync(query.userId);
        }
    }
}
