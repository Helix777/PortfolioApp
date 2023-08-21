using FluentValidation;
using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Application.Common.Interfaces.CQRS;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Items.Commands.AddItem
{
    public class AddItemCommandHandler : ICommandHandler<AddItemCommand>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IValidator<Item> _validator;

        public AddItemCommandHandler(IItemRepository itemRepository, IValidator<Item> validator)
        {
            _itemRepository = itemRepository;
            _validator = validator;
        }

        public async ValueTask Handle(AddItemCommand command, CancellationToken ct)
        {
            var i = new Item()
            {
                Code = command.Code,
                ColorId = command.ColorId,
                Comments = command.Comments,
                Name = command.Name
            };

            var result = await _validator.ValidateAsync(i, ct);

            if (result.IsValid)
            {
                _itemRepository.Add(i);

                await _itemRepository.SaveChangesAsync(ct);
            }
            else
                throw new ValidationException($"Item validation failed: {String.Join(", ", result.Errors)}");

            return;
        }
    }
}
