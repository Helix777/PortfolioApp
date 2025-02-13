using System.Linq.Expressions;

namespace PortfolioApp.Application.Common.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        Task SaveChangesAsync(CancellationToken ct);
    }
}
