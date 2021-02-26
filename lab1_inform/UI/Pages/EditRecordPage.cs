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
            var obj = StateSingleton.Context.Products.GetById(currentId);
            foreach(var property in properties)
            {
                Console.WriteLine($"Поле: {property.Name}");
            }
            Console.WriteLine("");
            this.Program.NavigateHome();
        }
    }
}
