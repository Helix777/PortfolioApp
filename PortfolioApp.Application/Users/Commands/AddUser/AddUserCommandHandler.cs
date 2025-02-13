using FluentValidation;
using Microsoft.AspNetCore.Identity;
using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Application.Common.Interfaces.CQRS;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Users.Commands.AddUser
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<User> _validator;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AddUserCommandHandler(IUserRepository userRepository, IValidator<User> validator, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _validator = validator;
            _passwordHasher = passwordHasher;
        }

        public async ValueTask Handle(AddUserCommand command, CancellationToken ct)
        {
            var user = new User()
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                RoleId = command.RoleId
            };
            user.Password = _passwordHasher.HashPassword(user, command.Password);

            var result = await _validator.ValidateAsync(user, ct);

            if (result.IsValid)
            {
                _userRepository.Add(user);

                await _userRepository.SaveChangesAsync(ct);
            }
            else
                throw new ValidationException($"Item validation failed: {String.Join(", ", result.Errors)}");

            return;
        }
    }
}
