using DAL.Entities;
using DAL.Repository;
using System;

namespace DAL
{
    public class DataContext
    {
        public DataContext(string repoType)
        {
            switch (repoType)
            {
                case "CSV":
                    BaseUsers = new CSVRepository<User>();
                    Orders = new CSVRepository<Order>();
                    Products = new CSVRepository<Product>();
                    Shops = new CSVRepository<Store>();
                    break;
                case "ADO":
                    BaseUsers = new ADORepository<User>();
                    Orders = new ADORepository<Order>();
                    Products = new ADORepository<Product>();
                    Shops = new ADORepository<Store>();
                    break;
                default:
                    throw new Exception($"Wrong repo type. Expected [ADO, CSV], got [{repoType}].");
            }
        }
        public IRepository<User> BaseUsers { get; set; } = null;

        public IRepository<Order> Orders { get; set; } = null;

        public IRepository<Product> Products { get; set; } = null;

        public IRepository<Store> Shops { get; set; } = null;
    }
}
