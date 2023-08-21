using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Common.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<IEnumerable<Item>> GetItems(int page, int pageSize);
        Task<Item> GetItemByIdAsync(int itemId);
    }
}
