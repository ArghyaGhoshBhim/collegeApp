using collegeApp.Model;
using Microsoft.EntityFrameworkCore;

namespace collegeApp.Data
{
    public class CollegeNewDBContext : DbContext
    {
        public CollegeNewDBContext(DbContextOptions<CollegeNewDBContext> options) : base(options) { }
        DbSet<Student> students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    StudentName = "Test",
                    Address = "Bhimpur",
                    Email = "arghya@gmail.com",
                    DOB = new DateTime(2022, 1,12)
                },
                new Student()
                {
                    Id = 2,
                    StudentName = "bappa",
                    Address = "Bhimpur",
                    Email = "bappa@gmail.com",
                    DOB = new DateTime(2020, 1,12)
                },
            }); ;
        }
    }
}
