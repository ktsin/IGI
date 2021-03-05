using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace lab1_inform.UI.Pages
{
    public class AddRecordPage : EasyConsoleCore.Page
    {
        public AddRecordPage(EasyConsoleCore.Program prog) : base("Страница добавления записи", prog) { }

        public override void Display()
        {
            base.Display();
            Type current = null;
            dynamic context = null;
            switch (StateSingleton.SelectedTable)
            {
                case (StateSingleton.Table.BaseUser):
                    context = StateSingleton.Context.BaseUsers;
                    current = typeof(DAL.Entities.BaseUser);
                    break;
                case (StateSingleton.Table.Order):
                    context = StateSingleton.Context.Orders;
                    current = typeof(DAL.Entities.Order);
                    break;
                case (StateSingleton.Table.Product):
                    current = typeof(DAL.Entities.Product);
                    context = StateSingleton.Context.Products;
                    break;
                case (StateSingleton.Table.Shop):
                    current = typeof(DAL.Entities.Shop);
                    context = StateSingleton.Context.Shops;
                    break;
                default:
                    this.Program.NavigateHome();
                    break;
            }
            var properties = current.GetProperties().Skip(1);
            object obj = current.GetConstructor(new Type[] { }).Invoke(new object[] { });
            if (obj == null)
            {
                Console.WriteLine("Запись не найдена!");
                Console.ReadKey();
                this.Program.NavigateHome();
            }
            foreach (var property in properties)
            {
                Console.WriteLine($"Поле: {property.Name}, Тип: {property.PropertyType.Name}");
                var str = "";
                while (String.IsNullOrWhiteSpace(str))
                {
                    str = EasyConsoleCore.Input.ReadString("Введите новое значение (пусто => не изменяем): ");
                    Console.WriteLine($"Echo : {str}");
                }
                object result = null;
                if (property.PropertyType != typeof(string) && property.PropertyType != typeof(DateTime))
                {
                    result = property.PropertyType
                                        .GetMethod("Parse", new Type[] { typeof(String), typeof(IFormatProvider) })
                                        .Invoke(null, new object[] { str, CultureInfo.InvariantCulture });
                }
                else
                {
                    if(property.PropertyType == typeof(string))
                        result = str;
                    else
                    {
                        //ДАТА
                        result = DateTime.ParseExact(str, "dd.mm.yyyy", CultureInfo.InvariantCulture);
                    }
                }
                property.SetMethod.Invoke(obj, new object[] { result });
            }
            context.GetType().GetMethod("Append").Invoke(context, new object[] { obj });
            Console.WriteLine("");
            Console.ReadKey();
            this.Program.NavigateHome();
        }
    }
}
