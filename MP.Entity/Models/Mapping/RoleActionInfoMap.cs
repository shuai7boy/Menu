using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MP.Entity.Models.Mapping
{
    public class RoleActionInfoMap : EntityTypeConfiguration<RoleActionInfo>
    {
        public RoleActionInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleActionID);

            // Properties
            this.Property(t => t.ActionID)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("RoleActionInfo");
            this.Property(t => t.RoleActionID).HasColumnName("RoleActionID");
            this.Property(t => t.RoleID).HasColumnName("RoleID");
            this.Property(t => t.ActionID).HasColumnName("ActionID");
        }
    }
}
