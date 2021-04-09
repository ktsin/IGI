using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IService<T> where T : DTO.IDTO, new()
    {
        public bool Add(T obj);

        public bool Update(T obj);

        public bool Delete(int id);

        public IEnumerable<T> ReadAll();

        public T GetById(int Id);
    }
}
