using FluentValidation;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Items.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Code).NotEmpty().Length(3, 12);
            RuleFor(x => x.Name).NotEmpty().Length(3, 200);
            RuleFor(x => x.ColorId).NotEmpty();
            RuleFor(x => x.Color).NotNull();
        }
    }
}
