using BLL.DTO;
using BLL.DTO.Converters;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class OrderService : Interfaces.IOrderService
    {
        public OrderService(DAL.IRepository<DAL.Entities.Order> repository)
        {
            this.repository = repository;
        }
        public bool Add(OrderDTO obj)
        {
            repository.Append(obj.FromOrderDTO());
            return true;
        }

        public bool Delete(int id)
        {
            repository.Delete(id);
            return true;
        }

        public OrderDTO GetById(int Id)
        {
            return repository.GetById(Id).ToOrderDTO();
        }

        public IEnumerable<OrderDTO> ReadAll()
        {
            return repository.Read().Select(e => e.ToOrderDTO());
        }

        public bool Update(OrderDTO obj)
        {
            repository.Update(obj.FromOrderDTO());
            return true;
        }

        private readonly DAL.IRepository<DAL.Entities.Order> repository = null;
    }
}
