using Core.DataAccess.Abstract;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete
{
    public class RepositoryBase<T, TContext> : IRepository<T>
        where T : class, IEntity, new()
        where TContext : DbContext
    {
        public RepositoryBase(TContext context)
        {
            Context = context;
        }
        protected TContext Context { get; }
        public T Add(T t)
        {
            return Context.Add(t).Entity;
        }

        public void AddRange(List<T> range)
        {
            Context.AddRange(range);
        }

        public void Delete(T t)
        {
            Context.Remove(t);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? Context.Set<T>().AsNoTracking().ToList()
                : Context.Set<T>().Where(filter).AsNoTracking().ToList();
        }

        public List<T> GetAll(int pageNumber, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> queryable = Context.Set<T>();
            queryable = queryable.AsNoTracking();

            if (filter != null)
                queryable = queryable.Where(filter);

            return orderBy(queryable).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().SingleOrDefault(filter);
        }

        public T Update(T t)
        {
            return Context.Update(t).Entity;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
