using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class EFDataContext : Interfaces.EFCore.EFContextBasic
    {
        public EFDataContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=data.sqlite3;")
                .UseLazyLoadingProxies();
        }

        public override DbSet<DAL.Entities.Order> Orders { get; set; }

        public override DbSet<DAL.Entities.Product> Products { get; set; }

        public override DbSet<DAL.Entities.User> Users { get; set; }

        public override DbSet<DAL.Entities.Store> Stores { get; set; }
    }
}
