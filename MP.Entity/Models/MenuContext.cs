using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MP.Entity.Models.Mapping;

namespace MP.Entity.Models
{
    public partial class MenuContext : DbContext
    {
        static MenuContext()
        {
            Database.SetInitializer<MenuContext>(null);
        }

        public MenuContext()
            : base("Name=MenuContext")
        {
        }

        public DbSet<ActionInfo> ActionInfoes { get; set; }
        public DbSet<RoleActionInfo> RoleActionInfoes { get; set; }
        public DbSet<RoleInfo> RoleInfoes { get; set; }
        public DbSet<UserActionInfo> UserActionInfoes { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }
        public DbSet<UserRoleInfo> UserRoleInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ActionInfoMap());
            modelBuilder.Configurations.Add(new RoleActionInfoMap());
            modelBuilder.Configurations.Add(new RoleInfoMap());
            modelBuilder.Configurations.Add(new UserActionInfoMap());
            modelBuilder.Configurations.Add(new UserInfoMap());
            modelBuilder.Configurations.Add(new UserRoleInfoMap());
        }
    }
}
