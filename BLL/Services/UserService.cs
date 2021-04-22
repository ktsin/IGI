using BLL.DTO;
using BLL.DTO.Converters;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService : Interfaces.IUserService
    {
        public UserService(DAL.Interfaces.EntityInterfaces.IUserRepository repository)
        {
            this.repository = repository;
        }
        public bool Add(UserDTO obj)
        {
            repository.Add(obj.FromUserDTO());
            return true;
        }

        public bool Delete(int id)
        {
            repository.RemoveById(id);
            return true;
        }

        public UserDTO GetById(int Id)
        {
            return repository.GetById(Id).ToUserDTO();
        }

        public IEnumerable<UserDTO> ReadAll()
        {
            return repository.GetAll().Select(e => e.ToUserDTO());
        }

        public bool Update(UserDTO obj)
        {
            repository.Update(obj.Id, obj.FromUserDTO());
            return true;
        }

        private readonly DAL.Interfaces.EntityInterfaces.IUserRepository repository = null;
    }
}
