using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repository;

namespace DAL
{
    public class DataContext
    {
        public DataContext(string repoType)
        {
            switch (repoType)
            {
                case "CSV":
                    BaseUsers = new CSVRepository<BaseUser>();
                    Orders = new CSVRepository<Order>();
                    Products = new CSVRepository<Product>();
                    Shops = new CSVRepository<Shop>();
                    break;
                case "ADO":
                    BaseUsers = new ADORepository<BaseUser>();
                    Orders = new ADORepository<Order>();
                    Products = new ADORepository<Product>();
                    Shops = new ADORepository<Shop>();
                    break;
                default:
                    throw new Exception($"Wrong repo type. Expected [ADO, CSV], got [{repoType}].");
            }
        }
        public IRepository<BaseUser> BaseUsers { get; set; } = null;

        public IRepository<Order> Orders { get; set; } = null;

        public IRepository<Product> Products { get; set; } = null;

        public IRepository<Shop> Shops { get; set; } = null;
    }
}
