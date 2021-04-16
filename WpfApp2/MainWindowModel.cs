using BLL.DTO;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        public MainWindowModel(IOrderService orderService,
            IProductService productService,
            IStoreService storeService,
            IUserService userService)
        {
            this.userService = userService;
            this.storeService = storeService;
            this.productService = productService;
            this.orderService = orderService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ObservableCollection<UserDTO> UserDTOs { get { return new ObservableCollection<UserDTO>(userService?.ReadAll()); } }

        public ObservableCollection<StoreDTO> StoreDTOs { get; set; }

        public ObservableCollection<ProductDTO> ProductDTOs { get; set; }

        public ObservableCollection<OrderDTO> OrderDTOs { get; set; }

        public List<string> TableNames { get; } = new List<string>() { "Заказы", "Пользователи", "Товары", "Магазины" };

        private readonly IOrderService orderService = null;
        private readonly IProductService productService = null;
        private readonly IStoreService storeService = null;
        private readonly IUserService userService = null;

    }
}
