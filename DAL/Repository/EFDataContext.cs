using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class EFDataContext : Interfaces.EFCore.EFContextBasic
    {
        public EFDataContext(DbContextOptions<EFDataContext> conf) : base(conf)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //Database.EnsureCreated();
        }
        public EFDataContext()
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override DbSet<DAL.Entities.Order> Orders { get; set; }

        public override DbSet<DAL.Entities.Product> Products { get; set; }

        public override DbSet<DAL.Entities.User> Users { get; set; }

        public override DbSet<DAL.Entities.Store> Stores { get; set; }
    }
}
