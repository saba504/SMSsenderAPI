using Microsoft.EntityFrameworkCore;
using SMSsenderAPI.Data;
using SMSsenderAPI.Interfaces;

namespace SMSsenderAPI.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext context;
        public Repository(DataContext context)
        {
            this.context = context;
        }

        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> Existed(int id)
        {
            var result = await context.Set<T>().FindAsync(id);
            if (result != null)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task Update(int id, T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
