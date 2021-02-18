using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DAL.Repository
{
    public class ADORepository<T> : IRepository<T>
    {
        public void Append(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Открывает соединение с БД.
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД</param>
        /// <returns></returns>
        public bool Open(string connectionString)
        {
            
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> Read()
        {
            throw new NotImplementedException();
        }
    }
}
