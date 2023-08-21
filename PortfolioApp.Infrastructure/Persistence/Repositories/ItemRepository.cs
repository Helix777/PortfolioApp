using Microsoft.EntityFrameworkCore;
using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Infrastructure.Persistence.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Item>> GetItems(int page, int pageSize)
        {
            return await _context.Items.Include(p => p.Color)
                 .Skip(pageSize * (page - 1))
                 .Take(pageSize).ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            return await _context.Items.Include(p => p.Color).FirstOrDefaultAsync(x => x.Id == itemId);
        }
    }
}
