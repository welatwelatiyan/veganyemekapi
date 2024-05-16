using System.Linq.Expressions;
using VY.Core.Layer.Entity;

namespace VY.Core.Layer.DataAcess.EFCore
{
    public interface IBaseRepository<T> where T : class,IEntity
    {
        bool add(T entity);
        Task<bool> addRange(List<T> entities);

        bool delete(Guid Id);
        Task<bool> deleteAll(List<Guid> IdList);

        bool update(T entity);
        Task<bool> updateAll(List<T> entities);

        T getById(Guid Id);
        IQueryable<T> getByFilterOrAll(Expression<Func<T,bool>>? filter = null);

        
    }
}
