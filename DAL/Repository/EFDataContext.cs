using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Repository
{
    public class EFDataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EFDataContext(){
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=data.sqlite3;")
                .UseLazyLoadingProxies();
        }

        public DbSet<DAL.Entities.Order> Orders { get; set; }

        public DbSet<DAL.Entities.Product> Products { get; set; }

        public DbSet<DAL.Entities.User> Users { get; set; }

        public DbSet<DAL.Entities.Store> Stores { get; set; }
    }
}
