using collegeApp.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace collegeApp.Data.Config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            //[Key]
            builder.HasKey(x => x.Id);
            //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(n => n.Name).IsRequired();
            builder.Property(n => n.Name).HasMaxLength(50);
            builder.Property(n => n.Description).HasMaxLength(60).IsRequired(false);
            builder.HasData(new List<Department>()
            {
                new Department()
                {
                    Id = 1,
                   Name = "EE",
                   Description="EE description"
                },
                new Department()
                {
                    Id = 2,
                   Name = "ECE",
                   Description="ECE description"
                },
            });

        }
    }
}

