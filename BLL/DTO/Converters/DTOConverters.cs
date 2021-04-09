using DAL.Entities;

namespace BLL.DTO.Converters
{
    public static class DTOConverters
    {
        #region ToDTO
        public static OrderDTO ToOrderDTO(this DAL.Entities.Order order)
        {
            var mapper = OrderDTO.mapConfig.CreateMapper();
            return mapper.Map<OrderDTO>(order);
        }

        public static ProductDTO ToProductDTO(this DAL.Entities.Product product)
        {
            var mapper = ProductDTO.mapConfig.CreateMapper();
            return mapper.Map<ProductDTO>(product);
        }

        public static StoreDTO ToProductDTO(this DAL.Entities.Store store)
        {
            var mapper = StoreDTO.mapConfig.CreateMapper();
            return mapper.Map<StoreDTO>(store);
        }

        public static UserDTO ToUserDTO(this DAL.Entities.User user)
        {
            var mapper = UserDTO.mapConfig.CreateMapper();
            return mapper.Map<UserDTO>(user);
        }
        #endregion
        #region FromDTO
        public static User FromUserDTO(this UserDTO userDTO)
        {
            var mapper = UserDTO.mapConfig.CreateMapper();
            return mapper.Map<User>(userDTO);
        }

        public static Product FromProductDTO(this ProductDTO productDTO)
        {
            var mapper = ProductDTO.mapConfig.CreateMapper();
            return mapper.Map<Product>(productDTO);
        }

        public static Store FromStoreDTO(this StoreDTO storeDTO)
        {
            var mapper = StoreDTO.mapConfig.CreateMapper();
            return mapper.Map<Store>(storeDTO);
        }

        public static Order FromOrderDTO(this OrderDTO orderDTO)
        {
            var mapper = OrderDTO.mapConfig.CreateMapper();
            return mapper.Map<Order>(orderDTO);
        }
        #endregion
    }
}
