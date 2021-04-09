using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T> : IDisposable
    {

        public bool Open();

        public void Close();

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public bool RemoveById(int Id);

        public bool Add(T record);

        public bool Update(int Id, T editedRecord);

        public string ConnectionString { get; set; }
    }
}
