using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MP.Entity.Models.Mapping
{
    public class UserRoleInfoMap : EntityTypeConfiguration<UserRoleInfo>
    {
        public UserRoleInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.UserRoleID);

            // Properties
            this.Property(t => t.RoleID)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("UserRoleInfo");
            this.Property(t => t.UserRoleID).HasColumnName("UserRoleID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.RoleID).HasColumnName("RoleID");
        }
    }
}
