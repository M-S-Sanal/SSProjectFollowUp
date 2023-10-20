using System.Linq.Expressions;
namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetAllTakeOne();

        void Add(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        T GetFirstOrDefaultWith(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        IEnumerable<T> Where(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetWith(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");


    }
}
