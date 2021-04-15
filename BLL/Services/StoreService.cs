using BLL.DTO;
using BLL.DTO.Converters;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class StoreService : Interfaces.IStoreService
    {
        public StoreService(DAL.IRepository<DAL.Entities.Store> repository)
        {
            this.repository = repository;
        }
        public bool Add(StoreDTO obj)
        {
            repository.Append(obj.FromStoreDTO());
            return true;
        }

        public bool Delete(int id)
        {
            repository.Delete(id);
            return true;
        }

        public StoreDTO GetById(int Id)
        {
            return repository.GetById(Id).ToStoreDTO();
        }

        public IEnumerable<StoreDTO> ReadAll()
        {
            return repository.Read().Select(e => e.ToStoreDTO());
        }

        public bool Update(StoreDTO obj)
        {
            repository.Update(obj.FromStoreDTO());
            return true;
        }

        private readonly DAL.IRepository<DAL.Entities.Store> repository = null;
    }
}
