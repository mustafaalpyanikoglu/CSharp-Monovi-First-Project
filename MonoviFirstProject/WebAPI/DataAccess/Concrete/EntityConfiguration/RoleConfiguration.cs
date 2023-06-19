using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            #region Role Model Creation
            builder.ToTable("Roles").HasKey(k => k.Id);
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Description).HasColumnName("Description");
            builder.Property(u => u.RoleName).HasColumnName("RoleName").IsRequired();

            #endregion

            Role[] roleSeeds =
            {
                new(1, "admin", "Bütün işlemleri yapabilir"),
                new(2, "customer", "Yaptığı işlemler kısıtlı")
            };
            builder.HasData(roleSeeds);
        }
    }
}
