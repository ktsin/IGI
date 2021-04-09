using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OwnerId { get; set; }

        public string LabelPhotoPath { get; set; }

        public string Location { get; set; }

        public float Raiting { get; set; }

        public static readonly MapperConfiguration mapConfig = new(e => { e.CreateMap<Store, StoreDTO>(); e.CreateMap<StoreDTO, Store>(); });
    }
}
