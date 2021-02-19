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
                new Option("Магазины", ()=> { }),
                new Option("Товары", () => { }),
                new Option("Пользователи", () => { }),
                new Option("Заказы", () => { })
            ) {}

        public override void Display()
        {
            base.Display();

        }
    }
}
