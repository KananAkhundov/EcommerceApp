using System.Linq.Expressions;

namespace Core.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        T Add(T t);
        T Update(T t);
        void Delete(T t);
        void AddRange(List<T> range);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(int pageNumber, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> filter = null);
        T GetById(Expression<Func<T, bool>> filter);
        int SaveChanges();
    }
}
