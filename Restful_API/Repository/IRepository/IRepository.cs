using Restful_API.Models;
using System.Linq.Expressions;

namespace Restful_API.Repository.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null, int pageSize = 0, int pageNumer = 1);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, int pageSize = 0, int pageNumer = 1);
        Task AddAsync(T entity);

        Task AddRangAsync(IEnumerable<T> entities);

        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entity);
    }
}
