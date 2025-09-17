using collegeApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace collegeApp.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x=>x.Username).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Password).IsRequired().HasMaxLength(50);
            builder.Property(x => x.IsActived).IsRequired();
            builder.Property(x=>x.UserType).IsRequired();
            builder.Property(x=>x.CreatedDate).IsRequired();

        }
    }
}
