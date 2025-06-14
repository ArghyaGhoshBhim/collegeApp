using collegeApp.Model;
using Microsoft.EntityFrameworkCore;

namespace collegeApp.Data
{
    public class CollegeNewDBContext : DbContext
    {
        public CollegeNewDBContext(DbContextOptions<CollegeNewDBContext> options) : base(options) { }
        DbSet<Student> students { get; set; }
    }
}
