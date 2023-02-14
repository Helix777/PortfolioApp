using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Application.Common.Interfaces.CQRS;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Items.Queries.GetItems
{
    public class GetItemsQueryHandler : IQueryHandler<GetItemsQuery, IEnumerable<Item>>
    {
        private readonly IItemRepository _itemsRepository;

        public GetItemsQueryHandler(IItemRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public async ValueTask<IEnumerable<Item>> Handle(GetItemsQuery query, CancellationToken cancellation)
        {
            var (page, pageSize) = query;
            return await _itemsRepository.GetItems(page, pageSize);
        }
    }
}
