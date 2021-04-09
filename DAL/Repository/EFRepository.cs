using System;
using System.Collections.Generic;

namespace DAL.Repository
{
    class EFRepository<T> : IRepository<T>, IDisposable where T : DAL.Entities.BaseEntity, new()
    {
        public void Append(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Open(string connectionString)
        {
            throw new NotImplementedException();
        }

        public List<T> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }


    }
}
