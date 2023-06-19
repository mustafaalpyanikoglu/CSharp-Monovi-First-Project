using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region User Model Creation
            builder.ToTable("Users").HasKey(k => k.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.RoleId).HasColumnName("RoleId");
            builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(u => u.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();

            //builder.HasOne(u => u.Role).WithMany().HasForeignKey(x => x.RoleId);
            #endregion
        }
    }
}
