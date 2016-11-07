using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MP.Entity.Models.Mapping
{
    public class ActionInfoMap : EntityTypeConfiguration<ActionInfo>
    {
        public ActionInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.ActionID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(20);

            this.Property(t => t.ICON)
                .HasMaxLength(50);

            this.Property(t => t.ActionName)
                .HasMaxLength(30);

            this.Property(t => t.ControllerName)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("ActionInfo");
            this.Property(t => t.ActionID).HasColumnName("ActionID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ICON).HasColumnName("ICON");
            this.Property(t => t.ActionName).HasColumnName("ActionName");
            this.Property(t => t.ControllerName).HasColumnName("ControllerName");
            this.Property(t => t.ParID).HasColumnName("ParID");
        }
    }
}
