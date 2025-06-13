using collegeApp.Model;
using Microsoft.EntityFrameworkCore;

namespace collegeApp.Data
{
    public class CollegeDBContext : DbContext
    {
        DbSet<Student> students { get; set; }
    }
}
