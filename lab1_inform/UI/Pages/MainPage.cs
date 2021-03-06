﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsoleCore;

namespace lab1_inform.UI.Pages
{
    public class MainPage : EasyConsoleCore.MenuPage
    {
        public MainPage(EasyConsoleCore.Program prog) :
            base("Главная страниица", prog,
                new Option("Просмотр данных", () => { 
                    StateSingleton.State = StateSingleton.Mode.View;
                    prog.NavigateTo<EntitySelectionPage>(); }),
                new Option("Открыть SQL источник", () => {
                    StateSingleton.State = StateSingleton.Mode.Connection;
                    prog.NavigateTo<SQLConnectionPoposal>();
                }),
                new Option("Открыть CSV источник", () => {
                    StateSingleton.State = StateSingleton.Mode.Connection;
                    prog.NavigateTo<CSVConnectionProposal>();
                }),
                new Option("Удалить данные", () => {
                    StateSingleton.State = StateSingleton.Mode.Remove;
                    prog.NavigateTo<EntitySelectionPage>();
                }),
                new Option("Редактирвоать данные", () => {
                    StateSingleton.State = StateSingleton.Mode.Edit;
                    prog.NavigateTo<EntitySelectionPage>();
                }),
                new Option("Вставить данные", () => {
                    StateSingleton.State = StateSingleton.Mode.Append;
                    prog.NavigateTo<EntitySelectionPage>();
                })
                ) { }

        public override void Display()
        {
            Console.WriteLine($"Строка подключения: {StateSingleton.ConnectionString}");
            base.Display();
        }
    }
}
