using collegeApp.Model;
using Microsoft.EntityFrameworkCore;

namespace collegeApp.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeNewDBContext _dbContext;
        public StudentRepository(CollegeNewDBContext dBContext) {
            _dbContext = dBContext;
        }

        public async Task<int> Create(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("Student is not valid");
            
            await _dbContext.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return student.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _dbContext.students.FirstOrDefaultAsync(x => x.Id == id);
            if(student == null)
            {
                return false;
            }
            _dbContext.students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<Student>> GetALL()
        {
            return await _dbContext.students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            var student = await _dbContext.students.FirstOrDefaultAsync(student => student.Id == id);
            return student;
        }

        public async Task<Student> GetByName(string name)
        {
            var student = await _dbContext.students.FirstOrDefaultAsync(student => student.StudentName.ToLower().Equals(name.ToLower()));
            return student;
        }

        public async Task<int> Update(Student student)
        {
            var studentToUpdate=await _dbContext.students.FirstOrDefaultAsync(ele=>ele.Id==student.Id);
            if (studentToUpdate == null) throw new ArgumentNullException("Student is not valid");
            studentToUpdate.StudentName = student.StudentName;
            studentToUpdate.Email = student.Email;
            studentToUpdate.Address = student.Address;
            studentToUpdate.DOB = student.DOB;
            await _dbContext.SaveChangesAsync();
            return studentToUpdate.Id; 
        }
    }
}
