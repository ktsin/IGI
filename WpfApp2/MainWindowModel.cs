using BLL.DTO;
using System.Linq;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Collections;

namespace WpfApp
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        private readonly IOrderService orderService = null;
        private readonly IProductService productService = null;
        private readonly IStoreService storeService = null;
        private readonly IUserService userService = null;

        public MainWindowModel(
            IOrderService orderService,
            IProductService productService,
            IStoreService storeService,
            IUserService userService)
        {
            this.userService = userService;
            this.storeService = storeService;
            this.productService = productService;
            this.orderService = orderService;
            nameTableMapping.Add("Заказы", () => new ObservableCollection<object>(orderService?.ReadAll()));
            nameTableMapping.Add("Пользователи", () => new ObservableCollection<object>(userService?.ReadAll()));
            nameTableMapping.Add("Товары", () => new ObservableCollection<object>(productService?.ReadAll()));
            nameTableMapping.Add("Магазины", () => new ObservableCollection<object>(storeService?.ReadAll()));
            nameServiceIndexMapping.Add("Заказы", 3);
            nameServiceIndexMapping.Add("Пользователи", 0);
            nameServiceIndexMapping.Add("Товары", 2);
            nameServiceIndexMapping.Add("Магазины", 1);
            services[0] = (userService);
            services[1] = (storeService);
            services[2] = (productService);
            services[3] = (orderService);

            CurrentTable.CollectionChanged += CurrentTable_CollectionChanged;
        }

        private void CurrentTable_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    foreach (var k in e.NewItems)
                    {
                        services[nameServiceIndexMapping[_selectedTable]].Add(k);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    var oldUser = e.OldItems[0];
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    var replacedUser = e.OldItems[0];
                    var replacingUser = e.NewItems[0];
                    //Console.WriteLine($"Объект {replacedUser.Name} заменен объектом {replacingUser.Name}");
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private string _selectedTable = "Заказы";
        public string SelectedTable { get => _selectedTable; set { _selectedTable = value; OnPropertyChanged("CurrentTable"); CurrentTable.CollectionChanged += CurrentTable_CollectionChanged;} }

        public List<string> TableNames { get; } = new List<string>() { "Заказы", "Пользователи", "Товары", "Магазины" };

        public ObservableCollection<object> CurrentTable
        {
            get
            {
                var table = nameTableMapping[_selectedTable]();
                table.CollectionChanged += CurrentTable_CollectionChanged;
                return table;
            }
        }

        private readonly Dictionary<string, System.Func<ObservableCollection<object>>> nameTableMapping = new();

        private readonly Dictionary<string, int> nameServiceIndexMapping = new();

        private readonly dynamic[] services = new dynamic[4];
        private void OnCollectionChanged()
        {

        }
    }
}
