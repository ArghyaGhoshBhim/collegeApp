using collegeApp.Model;
using System.Linq.Expressions;

namespace collegeApp.Data.Repository
{
    public interface ICollegeRepository<T>
    {
        Task<List<T>> GetALL();
        Task<T> GetById(Expression<Func<T, bool>> filter, bool isNoTracking = false);
        Task<T> GetByName(Expression<Func<T, bool>> filter);
        Task<T> Create(T dbRecord);
        Task<T> Update(T dbRecord);
        Task<bool> Delete(T dbRecord);
    }
}
