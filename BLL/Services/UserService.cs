using BLL.DTO;
using System.Linq;
using BLL.DTO.Converters;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : Interfaces.IUserService
    {
        public UserService(DAL.IRepository<DAL.Entities.User> repository)
        {
            this.repository = repository;
        }
        public bool Add(UserDTO obj)
        {
            repository.Append(obj.FromUserDTO());
            return true;
        }

        public bool Delete(int id)
        {
            repository.Delete(id);
            return true;
        }

        public UserDTO GetById(int Id)
        {
            return repository.GetById(Id).ToUserDTO();
        }

        public IEnumerable<UserDTO> ReadAll()
        {
            return repository.Read().Select(e => e.ToUserDTO());
        }

        public bool Update(UserDTO obj)
        {
            throw new NotImplementedException();
        }

        private readonly DAL.IRepository<DAL.Entities.User> repository = null;
    }
}
