using collegeApp.Model;

namespace collegeApp.Data.Repository
{
    public interface IStudentRepository:ICollegeRepository<Student>
    {
       Task<List<Student>> GetStudentsByFreeStatusAsync(int feeStatus);
    }
}
