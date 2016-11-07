using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MP.Entity.Models.Mapping
{
    public class UserActionInfoMap : EntityTypeConfiguration<UserActionInfo>
    {
        public UserActionInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.UserActionID);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserActionInfo");
            this.Property(t => t.UserActionID).HasColumnName("UserActionID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.ActionID).HasColumnName("ActionID");
            this.Property(t => t.IsTrue).HasColumnName("IsTrue");
        }
    }
}
