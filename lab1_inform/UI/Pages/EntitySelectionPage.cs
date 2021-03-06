﻿using System;
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
            switch (StateSingleton.State)
            {
                case StateSingleton.Mode.View:
                    this.Program.NavigateTo<DataViewPage>();
                    break;
                case StateSingleton.Mode.Remove:
                    this.Program.NavigateTo<DeleteRecordPage>();
                    break;
                case StateSingleton.Mode.Edit:
                    this.Program.NavigateTo<EditRecordPage>();
                    break;
                case StateSingleton.Mode.Append:
                    this.Program.NavigateTo<AddRecordPage>();
                    break;
            }
            
        }
    }
}
