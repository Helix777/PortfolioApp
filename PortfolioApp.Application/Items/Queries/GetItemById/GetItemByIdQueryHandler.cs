using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Application.Common.Interfaces.CQRS;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IQueryHandler<GetItemByIdQuery, Item>
    {
        private readonly IItemRepository _itemsRepository;

        public GetItemByIdQueryHandler(IItemRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }
        public async ValueTask<Item> Handle(GetItemByIdQuery query, CancellationToken cancellation)
        {
            return await _itemsRepository.GetItemByIdAsync(query.ItemId);
        }
    }
}
