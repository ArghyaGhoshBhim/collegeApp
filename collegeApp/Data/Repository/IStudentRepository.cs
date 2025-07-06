using collegeApp.Model;

namespace collegeApp.Data.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetALL();
        Task<Student> GetById(int id, bool isNoTracking=false);
        Task<Student> GetByName(string name);
        Task<int> Create(Student student);
        Task<int> Update(Student student);
        Task<bool>Delete(int id);
    }
}
