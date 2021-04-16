using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    class ContextFactory : IDesignTimeDbContextFactory<Repository.EFDataContext>
    {
        public DAL.Repository.EFDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Repository.EFDataContext>();
            optionsBuilder.UseSqlite("Data Source=data.sqlite3;");

            return new Repository.EFDataContext(optionsBuilder.Options);
        }
    }
}
