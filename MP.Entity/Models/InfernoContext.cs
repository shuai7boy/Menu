using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MP.Entity.Models.Mapping;

namespace MP.Entity.Models
{
    public partial class InfernoContext : DbContext
    {
        static InfernoContext()
        {
            Database.SetInitializer<InfernoContext>(null);
        }

        public InfernoContext()
            : base("Name=InfernoContext")
        {
        }

        public DbSet<music> musics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new musicMap());
        }
    }
}
