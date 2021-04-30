using BLL.DTO;
using BLL.DTO.Converters;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class OrderService : Interfaces.IOrderService
    {
        public OrderService(DAL.Interfaces.EntityInterfaces.IOrderRepository repository)
        {
            this.repository = repository;
        }
        public bool Add(OrderDTO obj)
        {
            repository.Add(obj.FromOrderDTO());
            return true;
        }

        public bool Add(object obj)
        {
            repository.Add((obj as OrderDTO)?.FromOrderDTO());
            return true;
        }

        public bool Delete(int id)
        {
            repository.RemoveById(id);
            return true;
        }

        public OrderDTO GetById(int Id)
        {
            return repository.GetById(Id).ToOrderDTO();
        }

        public IEnumerable<OrderDTO> ReadAll()
        {
            return repository.GetAll().Select(e => e.ToOrderDTO());
        }

        public bool Update(OrderDTO obj)
        {
            repository.Update(obj.Id, obj.FromOrderDTO());
            return true;
        }

        private readonly DAL.Interfaces.EntityInterfaces.IOrderRepository repository = null;
    }
}
