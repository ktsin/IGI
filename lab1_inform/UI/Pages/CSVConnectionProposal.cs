using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            bool isExist = false;
            string path = "";
            while (!isExist)
            {
                Console.WriteLine("Строка подключения к CSV источнику -- путь к папке," +
                    " содержащей *.csv с именами таблиц");
                path = Input.ReadString("Путь до папочки: ");
                isExist = Directory.Exists(path);
            }
            //opening repositories
            StateSingleton.Context = new("CSV");
            StateSingleton.Context.BaseUsers.Open(path);
            StateSingleton.Context.Orders.Open(path);
            StateSingleton.Context.Products.Open(path);
            StateSingleton.Context.Shops.Open(path);
        }
    }
}
