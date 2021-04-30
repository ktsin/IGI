using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities.EFCore
{
    public class ProductRepository : Interfaces.EntityInterfaces.IProductRepository
    {
        private bool disposedValue;

        public ProductRepository(Interfaces.EFCore.EFContextBasic context)
        {
            _context = context;
        }

        public string ConnectionString
        {
            get => _conStr;
            set => _conStr = $"Data Source={value};";
        }

        public bool Add(Product record)
        {
            try
            {
                this._context.Products.Add(record);
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

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _context.Products.AsEnumerable().ToList();
                //return _context.Products.Select(e => e).AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception($"In {this.GetType().Name} repository exception: {ex.Message}", ex);
            }
        }

        public Product GetById(int Id)
        {
            try
            {
                return (Product)_context.Products.Where(e => e.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"In {this.GetType().Name} repository exception: {ex.Message}", ex);
            }
        }

        [Obsolete]
        public bool Open()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int Id)
        {
            bool flag = true;
            try
            {
                Product element = _context.Products.Find(Id);
                _context.Products.Remove(element);
                _context.SaveChanges();
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update(int Id, Product editedRecord)
        {
            bool flag = true;
            try
            {
                _context.Products.Update(editedRecord);
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
