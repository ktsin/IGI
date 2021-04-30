using BLL.DTO;
using BLL.DTO.Converters;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class StoreService : Interfaces.IStoreService
    {
        public StoreService(DAL.Interfaces.EntityInterfaces.IStoreRepository repository)
        {
            this.repository = repository;
        }
        public bool Add(StoreDTO obj)
        {
            repository.Add(obj.FromStoreDTO());
            return true;
        }

        public bool Add(object obj)
        {
            repository.Add((obj as StoreDTO)?.FromStoreDTO());
            return true;
        }

        public bool Delete(int id)
        {
            repository.RemoveById(id);
            return true;
        }

        public StoreDTO GetById(int Id)
        {
            return repository.GetById(Id).ToStoreDTO();
        }

        public IEnumerable<StoreDTO> ReadAll()
        {
            return repository.GetAll().Select(e => e.ToStoreDTO());
        }

        public bool Update(StoreDTO obj)
        {
            repository.Update(obj.Id, obj.FromStoreDTO());
            return true;
        }

        private readonly DAL.Interfaces.EntityInterfaces.IStoreRepository repository = null;
    }
}
