using BLL.DTO;
using BLL.DTO.Converters;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ProductService : Interfaces.IProductService
    {
        public ProductService(DAL.IRepository<DAL.Entities.Product> repository)
        {
            this.repository = repository;
        }
        public bool Add(ProductDTO obj)
        {
            repository.Append(obj.FromProductDTO());
            return true;
        }

        public bool Delete(int id)
        {
            repository.Delete(id);
            return true;
        }

        public ProductDTO GetById(int Id)
        {
            return repository.GetById(Id).ToProductDTO();
        }

        public IEnumerable<ProductDTO> ReadAll()
        {
            return repository.Read().Select(e => e.ToProductDTO());
        }

        public bool Update(ProductDTO obj)
        {
            repository.Update(obj.FromProductDTO());
            return true;
        }

        private readonly DAL.IRepository<DAL.Entities.Product> repository = null;
    }
}
