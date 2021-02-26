using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsoleCore;

namespace lab1_inform.UI.Pages
{
    public class DataViewPage : EasyConsoleCore.Page
    {
        public DataViewPage(EasyConsoleCore.Program prog) : base("Просмотр данных", prog)
        {

        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Данные: ");
            List<object> data = new() { };
            Type current = null;
            switch (StateSingleton.SelectedTable)
            {
                case (StateSingleton.Table.BaseUser):
                    data = StateSingleton.Context.BaseUsers.Read().ToList<object>();
                    current = typeof(DAL.Entities.BaseUser);
                    break;
                case (StateSingleton.Table.Order):
                    data = StateSingleton.Context.Orders.Read().ToList<object>();
                    current = typeof(DAL.Entities.Order);
                    break;
                case (StateSingleton.Table.Product):
                    current = typeof(DAL.Entities.Product);
                    data = StateSingleton.Context.Products.Read().ToList<object>();
                    break;
                case (StateSingleton.Table.Shop):
                    current = typeof(DAL.Entities.Shop);
                    data = StateSingleton.Context.Shops.Read().ToList<object>();
                    break; 
            }
            Console.WriteLine(String.Join<System.Reflection.PropertyInfo>(", ", current.GetProperties()));
            foreach(var i in data)
            {
                Console.WriteLine(String.Join(", ", (i as DAL.Entities.BaseEntity).Serialize()));
                Console.WriteLine("");
            }
            Console.ReadKey();
            this.Program.NavigateHome();
        }
    }
}
