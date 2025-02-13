using FluentValidation;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Code).NotEmpty().Length(3, 12);
            RuleFor(x => x.Name).NotEmpty().Length(3, 200);
            RuleFor(x => x.ColorId).NotEmpty();
        }
    }
}
