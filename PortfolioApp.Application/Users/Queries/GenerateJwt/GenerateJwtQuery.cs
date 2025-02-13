using PortfolioApp.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioApp.Application.Users.Queries.GenerateJwt
{
    public record GenerateJwtQuery(LoginDto dto)
    {
        public static GenerateJwtQuery With(LoginDto dto)
        {
            return new(dto);
        }
    }
}
