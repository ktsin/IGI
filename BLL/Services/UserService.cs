﻿using BLL.DTO;
using BLL.DTO.Converters;
using System.Collections.Generic;
using System.Linq;

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
            repository.Update(obj.FromUserDTO());
            return true;
        }

        private readonly DAL.IRepository<DAL.Entities.User> repository = null;
    }
}
