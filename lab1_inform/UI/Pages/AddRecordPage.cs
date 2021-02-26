using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_inform.UI.Pages
{
    public class AddRecordPage : EasyConsoleCore.Page
    {
        public AddRecordPage(EasyConsoleCore.Program prog) : base("Страница добавления записи", prog) { }

        public override void Display()
        {
            base.Display();
            //Type current = null;
            //dynamic context = null;
            //switch (StateSingleton.SelectedTable)
            //{
            //    case (StateSingleton.Table.BaseUser):
            //        context = StateSingleton.Context.BaseUsers;
            //        current = typeof(DAL.Entities.BaseUser);
            //        break;
            //    case (StateSingleton.Table.Order):
            //        context = StateSingleton.Context.Orders;
            //        current = typeof(DAL.Entities.Order);
            //        break;
            //    case (StateSingleton.Table.Product):
            //        current = typeof(DAL.Entities.Product);
            //        context = StateSingleton.Context.Products;
            //        break;
            //    case (StateSingleton.Table.Shop):
            //        current = typeof(DAL.Entities.Shop);
            //        context = StateSingleton.Context.Shops;
            //        break;
            //    default:
            //        this.Program.NavigateHome();
            //        break;
            //}
            //var properties = current.GetProperties().Skip(1);
            //object obj = context.GetById(currentId);
            //if (obj == null)
            //{
            //    Console.WriteLine("Запись не найдена!");
            //    Console.ReadKey();
            //    this.Program.NavigateHome();
            //}
            //foreach (var property in properties)
            //{
            //    Console.WriteLine($"Поле: {property.Name}, Тип: {property.PropertyType.Name}");
            //    var str = EasyConsoleCore.Input.ReadString("Введите новое значение (пусто => не изменяем): ");
            //    Console.WriteLine($"Echo : {str}");
            //    if (!String.IsNullOrWhiteSpace(str))
            //    {
            //        var result = property.PropertyType
            //                .GetMethod("Parse", new Type[] { typeof(String) })
            //                .Invoke(null, new object[] { str });
            //        property.SetMethod.Invoke(obj, new object[] { result });
            //    }
            //}
            //Console.WriteLine("");
            //Console.ReadKey();
            //this.Program.NavigateHome();
        }
    }
}
