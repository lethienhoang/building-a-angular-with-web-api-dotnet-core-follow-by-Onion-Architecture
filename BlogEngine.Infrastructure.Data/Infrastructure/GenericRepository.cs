using BlogEngine.Core.Entities;
using BlogEngine.Infrastructure.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogEngine.Infrastructure.Data.Infrastructure
{
    public class GenericRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        private Core.Context.DatabaseContext context;
        private DbSet<T> dbset;

        public GenericRepository(Core.Context.DatabaseContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }



        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbset.Where(predicate).AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.AsEnumerable();
        }


        public T FindById(Guid id)
        {
            return dbset.SingleOrDefault(x => x.Id == id);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return dbset.FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbset;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual async Task<T> FindByIdAsync(Guid id)
        {
            return await dbset.SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbset.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbset;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual void Update(T entity)
        {
            dbset.Update(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbset.AnyAsync(predicate);
        }
    }
}
