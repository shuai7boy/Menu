using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MP.Entity.Models.Mapping
{
    public class musicMap : EntityTypeConfiguration<music>
    {
        public musicMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.title)
                .HasMaxLength(50);

            this.Property(t => t.author)
                .HasMaxLength(50);

            this.Property(t => t.url)
                .HasMaxLength(500);

            this.Property(t => t.pic)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("music");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.author).HasColumnName("author");
            this.Property(t => t.url).HasColumnName("url");
            this.Property(t => t.pic).HasColumnName("pic");
        }
    }
}
