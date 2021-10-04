using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HotDeskApp.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected HotDeskDBContext db { get; set; }
        public RepositoryBase(HotDeskDBContext context)
        {
            db = context;
        }

        public IQueryable<T> FindAll()
        {
            return db.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>()
                .Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            db.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
        }
    }
}
