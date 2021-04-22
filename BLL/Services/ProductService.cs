using BLL.DTO;
using BLL.DTO.Converters;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ProductService : Interfaces.IProductService
    {
        public ProductService(DAL.Interfaces.EntityInterfaces.IProductRepository repository)
        {
            this.repository = repository;
        }
        public bool Add(ProductDTO obj)
        {
            repository.Add(obj.FromProductDTO());
            return true;
        }

        public bool Delete(int id)
        {
            repository.RemoveById(id);
            return true;
        }

        public ProductDTO GetById(int Id)
        {
            return repository.GetById(Id).ToProductDTO();
        }

        public IEnumerable<ProductDTO> ReadAll()
        {
            return repository.GetAll().Select(e => e.ToProductDTO());
        }

        public bool Update(ProductDTO obj)
        {
            repository.Update(obj.Id, obj.FromProductDTO());
            return true;
        }

        private readonly DAL.Interfaces.EntityInterfaces.IProductRepository repository = null;
    }
}
