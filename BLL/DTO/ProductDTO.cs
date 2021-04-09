using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public float Price { get; set; }

        public int Discount { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public int ShopId { get; set; }

        public static readonly MapperConfiguration mapConfig = new(e => { e.CreateMap<Product, ProductDTO>(); e.CreateMap<ProductDTO, Product>(); });
    }
}
