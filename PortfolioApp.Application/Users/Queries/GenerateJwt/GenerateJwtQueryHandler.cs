using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Application.Common.Interfaces.CQRS;
using PortfolioApp.Application.Exceptions;
using PortfolioApp.Domain.Configurations;
using PortfolioApp.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortfolioApp.Application.Users.Queries.GenerateJwt
{
    public class GenerateJwtQueryHandler : IQueryHandler<GenerateJwtQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public GenerateJwtQueryHandler(IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            IOptions<AuthenticationSettings> options)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _authenticationSettings = options.Value;
        }

        public async ValueTask<string> Handle(GenerateJwtQuery query, CancellationToken cancellation)
        {
            var user = await _userRepository.GetUserByEmailAsync(query.dto.Email) ?? throw new BadRequestException("Invalid username or password");
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, query.dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim("Role", $"{user.Role.Name}")

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
    }
}
