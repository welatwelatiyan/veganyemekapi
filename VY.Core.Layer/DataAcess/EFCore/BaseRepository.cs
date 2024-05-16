using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VY.Core.Layer.Entity;

namespace VY.Core.Layer.DataAcess.EFCore
{
    public class BaseRepository<T, TContext> : IBaseRepository<T>
        where T : class, IEntity
        where TContext :DbContext
    {
        private readonly TContext context;
        public BaseRepository(TContext context)
        {
            this.context = context;
        }        
        public  bool add(T entity)
        {
            context.Set<T>().Add(entity);
            int changes=  context.SaveChanges();
            return changes > 0 ? true : false;

        }

        public async Task<bool> addRange(List<T> entities)
        {
            context.Set<T>().AddRange(entities);
            int changes = await context.SaveChangesAsync(); 
            return changes == entities.Count ? true : false;  
        }

        public bool delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> deleteAll(List<Guid> IdList)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> getByFilterOrAll(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ? context.Set<T>() : context.Set<T>().Where(filter);
        }

        public T getById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool update(T entity)
        {
            context.Set<T>().Update(entity);
            int changes =  context.SaveChanges();
            return changes > 0 ? true : false;
        }

        public async Task<bool> updateAll(List<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
            int changes = await context.SaveChangesAsync();
            return changes == entities.Count ? true : false;
        }
    }
}
