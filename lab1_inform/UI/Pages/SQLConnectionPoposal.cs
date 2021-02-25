using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsoleCore;
using System.IO;

namespace lab1_inform.UI.Pages
{
    public class SQLConnectionPoposal : EasyConsoleCore.Page
    {
        public SQLConnectionPoposal(EasyConsoleCore.Program program) : base("Выбор источника SQLITE", program)
        {}

        public override void Display()
        {
            base.Display();
            bool isOpened = false;
            string path = "";
            while (!isOpened)
            {
                Console.WriteLine("Строка подключения к SQLite источнику -- путь к файлу," +
                    " содержащему готовую БД");
                path = Input.ReadString("Полный путь до SQLite БД: ");
                isOpened = File.Exists(path);
                
            }
            StateSingleton.ConnectionString = path;
            //opening repositories
            StateSingleton.Context = new("ADO");
            StateSingleton.Context.BaseUsers.Open(path);
            StateSingleton.Context.Orders.Open(path);
            StateSingleton.Context.Products.Open(path);
            StateSingleton.Context.Shops.Open(path);
            Console.WriteLine("Подключено успешно!");
            Console.ReadKey();
            this.Program.NavigateHome();
        }
    }
}
