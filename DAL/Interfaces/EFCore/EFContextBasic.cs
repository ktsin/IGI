using DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces.EFCore
{
    public abstract class EFContextBasic : DbContext
    {
        public EFContextBasic(DbContextOptions<EFDataContext> conf) : base(conf) { }

        public virtual DbSet<DAL.Entities.Order> Orders { get; set; }

        public virtual DbSet<DAL.Entities.Product> Products { get; set; }

        public virtual DbSet<DAL.Entities.User> Users { get; set; }

        public virtual DbSet<DAL.Entities.Store> Stores { get; set; }
    }
}
