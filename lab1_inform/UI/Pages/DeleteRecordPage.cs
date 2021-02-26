using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_inform.UI.Pages
{
    public class DeleteRecordPage : EasyConsoleCore.Page
    {
        public DeleteRecordPage(EasyConsoleCore.Program prog) : base("Диалог удаления записи", prog)
        {

        }

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

            Console.WriteLine("Введите номер записи для удаления");
            int idToRecord = EasyConsoleCore.Input.ReadInt();
            try
            {
                context.Delete(idToRecord);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                this.Program.NavigateHome();
            }
        }
    }
}
