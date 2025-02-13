using FluentValidation;
using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.RoleId).NotEmpty();
            //RuleFor(p => p).
            //   MustAsync(IsEmailAlreadyExist)
            //   .WithMessage("Post with the same Title and Author already exist");
        }

        //    private async Task<bool> IsEmailAlreadyExist
        //(AddUserCommand e, CancellationToken cancellationToken)
        //    {
        //        var check = await _userRepository.
        //            IsNameAndAuthorAlreadyExist(e.Email);
        //        return !check;
        //    }
    }
}
