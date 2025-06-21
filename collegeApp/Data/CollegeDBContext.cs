using collegeApp.Data.Config;
using collegeApp.Model;
using Microsoft.EntityFrameworkCore;

namespace collegeApp.Data
{
    public class CollegeNewDBContext : DbContext
    {
        public CollegeNewDBContext(DbContextOptions<CollegeNewDBContext> options) : base(options) { }
        public DbSet<Student> students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Student>().HasData(new List<Student>()
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
            });*/

            /*modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(n => n.StudentName).IsRequired();
                entity.Property(n => n.StudentName).HasMaxLength(50);
                entity.Property(n => n.Address).IsRequired(false);
                entity.Property(n => n.Address).HasMaxLength(50);
                entity.Property(n => n.Email).IsRequired();
                entity.Property(n => n.Email).HasMaxLength(60);
            });*/

            modelBuilder.ApplyConfiguration(new StudenConfig());
        }
    }
}
