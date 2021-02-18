using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class DataContext
    {
        public IRepository<BaseUser> BaseUsers { get; set; } = null;

        public IRepository<Order> Orders { get; set; } = null;

        public IRepository<Product> Products { get; set; } = null;

        public IRepository<Shop> Shops { get; set; } = null;
    }
}
