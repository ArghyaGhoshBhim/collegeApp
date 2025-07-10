using collegeApp.Model;
using Microsoft.EntityFrameworkCore;

namespace collegeApp.Data.Repository
{
    public class StudentRepository :CollegeRepository<Student>, IStudentRepository
    {

        private readonly CollegeNewDBContext _dbContext;
        public StudentRepository(CollegeNewDBContext dBContext) : base(dBContext) {
            _dbContext = dBContext;
        }

        public Task<List<Student>> GetStudentsByFreeStatusAsync(int feeStatus)
        {
            return null;
        }
    }
}
