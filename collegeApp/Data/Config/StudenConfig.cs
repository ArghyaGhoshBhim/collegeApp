using collegeApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace collegeApp.Data.Config
{
    public class StudenConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            //[Key]
            builder.HasKey(x => x.Id);
            //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(n => n.StudentName).IsRequired();
            builder.Property(n => n.StudentName).HasMaxLength(50);
            builder.Property(n => n.Address).IsRequired(false);
            builder.Property(n => n.Address).HasMaxLength(50);
            builder.Property(n => n.Email).IsRequired();
            builder.Property(n => n.Email).HasMaxLength(60);
            builder.HasData(new List<Student>()
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
            });

        }
    }
}
