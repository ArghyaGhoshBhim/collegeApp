using collegeApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace collegeApp.Data.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.RoleName).IsRequired();
            builder.Property(x => x.IsActived).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();

        }
    }
}
