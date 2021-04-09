using BLL.DTO;
using DAL.Entities.EFCore;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class StoreService : Interfaces.IStoreService
    {
        public StoreService(StoreRepository repository)
        {
            this.repository = repository;
        }

        public bool Add(StoreDTO obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public StoreDTO GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoreDTO> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(StoreDTO obj)
        {
            throw new NotImplementedException();
        }

        private readonly StoreRepository repository = null;
    }
}
