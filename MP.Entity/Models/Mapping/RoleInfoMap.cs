using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MP.Entity.Models.Mapping
{
    public class RoleInfoMap : EntityTypeConfiguration<RoleInfo>
    {
        public RoleInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleID);

            // Properties
            this.Property(t => t.RoleName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("RoleInfo");
            this.Property(t => t.RoleID).HasColumnName("RoleID");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
        }
    }
}
