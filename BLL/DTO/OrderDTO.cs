using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int Buyer { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public float Price { get; set; }

        public static readonly MapperConfiguration mapConfig = new(e => { e.CreateMap<Order, OrderDTO>(); e.CreateMap<OrderDTO, Order>(); });
    }
}
