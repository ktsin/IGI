using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsoleCore;
using lab1_inform.UI;

namespace lab1_inform.UI.Pages
{
    public class EntitySelectionPage : EasyConsoleCore.MenuPage
    {
        public EntitySelectionPage(EasyConsoleCore.Program program) :
            base("Выбор таблицы", program, 
                new Option("Магазины", ()=> {
                    StateSingleton.SelectedTable = StateSingleton.Table.Shop;
                }),
                new Option("Товары", () => {
                    StateSingleton.SelectedTable = StateSingleton.Table.Product;
                }),
                new Option("Пользователи", () => {
                    StateSingleton.SelectedTable = StateSingleton.Table.BaseUser;
                }),
                new Option("Заказы", () => {
                    StateSingleton.SelectedTable = StateSingleton.Table.Order;
                })
            ) {}

        public override void Display()
        {
            base.Display();
            this.Program.NavigateTo<DataViewPage>();
        }
    }
}
