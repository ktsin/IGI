using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsoleCore;

namespace lab1_inform.UI.Pages
{
    public class CSVConnectionProposal : EasyConsoleCore.Page
    {
        public CSVConnectionProposal(EasyConsoleCore.Program prog) : 
            base("Ввод строки подключения для CSV источника.", prog) { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Строка подключения к CSV источнику -- путь к папке," +
                " содержащей *.csv с именами таблиц");
            string path = Input.ReadString("Путь до папочки: ");
            //opening repositories
            StateSingleton.Context = new();
            StateSingleton.Context.BaseUsers = new DAL.CSVRepository<DAL.Entities.BaseUser>();
            StateSingleton.Context.BaseUsers.Open(path);
            StateSingleton.Context.Orders = new DAL.CSVRepository<DAL.Entities.Order>();
            StateSingleton.Context.Orders.Open(path);
            StateSingleton.Context.Products = new DAL.CSVRepository<DAL.Entities.Product>();
            StateSingleton.Context.Products.Open(path);
            StateSingleton.Context.Shops = new DAL.CSVRepository<DAL.Entities.Shop>();
            StateSingleton.Context.Shops.Open(path);
        }
    }
}
