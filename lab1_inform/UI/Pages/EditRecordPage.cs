using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_inform.UI.Pages
{
    public class EditRecordPage : EasyConsoleCore.Page
    {
        public EditRecordPage(EasyConsoleCore.Program prog) : base("Форма редактирования записи", prog) { }

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
            Console.Write("Введите номер записи: ");
            int currentId = EasyConsoleCore.Input.ReadInt(1, Int32.MaxValue);
            DAL.Entities.BaseEntity obj = context.GetById(currentId);
            if(obj == null)
            {
                Console.WriteLine("Запись не найдена!");
                Console.ReadKey();
                this.Program.NavigateHome();
            }
            foreach(var property in properties)
            {
                Console.WriteLine($"Поле: {property.Name}, Тип: {property.PropertyType.Name}");
                var str = EasyConsoleCore.Input.ReadString("Введите новое значение (пусто => не изменяем): ");
                Console.WriteLine($"Echo : {str}");
                if (!String.IsNullOrWhiteSpace(str))
                {
                    var result = property.PropertyType
                            .GetMethod("Parse", new Type[] { typeof(String) })
                            .Invoke(null, new object[] { str });
                    property.SetMethod.Invoke(obj, new object[] { result });
                }
            }
            
            context.GetType().GetMethod("Update").Invoke(context, new object[] { obj });
            Console.WriteLine("");
            Console.ReadKey();
            this.Program.NavigateHome();
        }
    }
}
