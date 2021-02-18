using System;
using Xunit;
using DAL;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShopCSVRepositoryOpen()
        {
            DataContext cx = new();
            cx.Shops = new DAL.CSVRepository<DAL.Entities.Shop>();
            cx.Shops.Open(@"C:\Users\рлорло\Desktop\lab 1\lab 1\testCSV\");
        }

        [Fact]
        public void ShopCSVRepositoryWriter()
        {
            DataContext cx = new();
            cx.Shops = new DAL.CSVRepository<DAL.Entities.Shop>();
            cx.Shops.Open(@"C:\Users\рлорло\Desktop\lab 1\lab 1\testCSV\");
            cx.Shops.Append(new DAL.Entities.Shop() { Id = 100, Name="nil Shop", OwnerId = 2, Raiting = 3.1F});
        }

        [Fact]
        public void BaseUserCSVRepositoryOpen()
        {

        }
    }
}
