using System.Linq.Expressions;

namespace PomiaryEsp32.Data.Repositories
{
    public abstract class BaseCrudRepository<T, TKey> : IBaseRepository<T, TKey>
    {
        protected readonly DataContext context;

        public BaseCrudRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(TKey id)
        {
            var entity = await Get(id);
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public abstract Task<T> Get(TKey id);
        public abstract Task<List<T>> GetAll();
        public abstract Task<T> Get(Expression<Func<T, bool>> exp);
        public abstract Task<List<T>> GetAll(Expression<Func<T, bool>> exp);
    }
}
