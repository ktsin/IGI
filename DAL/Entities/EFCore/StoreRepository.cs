using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities.EFCore
{
    public class StoreRepository : Interfaces.EntityInterfaces.IStoreRepository
    {
        private bool disposedValue;

        public StoreRepository(Interfaces.EFCore.EFContextBasic context)
        {
            _context = context;
        }

        public string ConnectionString
        {
            get => _conStr;
            set => _conStr = $"Data Source={value};";
        }

        public bool Add(Store record)
        {
            try
            {
                this._context.Stores.Add(record);
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"In {this.GetType().Name} repository exception: {ex.Message}", ex);
            }
        }

        public void Close()
        {
            _context?.Dispose();
        }

        public IEnumerable<Store> GetAll()
        {
            try
            {
                return _context.Stores.AsEnumerable().ToList();
                //return _context.Stores.Select(e => e).AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception($"In {this.GetType().Name} repository exception: {ex.Message}", ex);
            }
        }

        public Store GetById(int Id)
        {
            try
            {
                return (Store)_context.Stores.Where(e => e.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"In {this.GetType().Name} repository exception: {ex.Message}", ex);
            }
        }

        public bool Open()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int Id)
        {
            bool flag = true;
            try
            {
                var element = _context.Stores.Find(Id);
                _context.Stores.Remove(element);
                _context.SaveChanges();
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update(int Id, Store editedRecord)
        {
            bool flag = true;
            try
            {
                _context.Stores.Update(editedRecord);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Close();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private string _conStr = null;

        private Interfaces.EFCore.EFContextBasic _context = null;
    }
}
