using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRepository<T>
    {
        bool Open(string connectionString);

        void Append(T entity);

        List<T> Read();

        T GetById(int id);

        void Update(T entity);

        void Delete();
    }
}
