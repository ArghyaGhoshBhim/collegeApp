using collegeApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace collegeApp.Data.Repository
{
    public class CollegeRepository<T>:ICollegeRepository<T> where T : class
    {

        private readonly CollegeNewDBContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public CollegeRepository(CollegeNewDBContext dBContext) { 
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> Create(T dbRecord)
        {
            if (dbRecord == null)
            {
                throw new ArgumentNullException("Student is not valid");
            }
                

            await _dbSet.AddAsync(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }


        public async Task<bool> Delete(T dbRecord)
        {
            if (dbRecord == null)
            {
                return false;
            }
            _dbSet.Remove(dbRecord);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<T>> GetALL()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> filter, bool isNoTracking = false)
        {


            if (isNoTracking)
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter);
            }

             return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByName(Expression<Func<T, bool>> filter)
        {
            var student = await _dbSet.Where(filter).FirstOrDefaultAsync();
            return student;
        }

        public async Task<T> Update(T dbRecord)
        {
            _dbContext.Update(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }
    }
}
