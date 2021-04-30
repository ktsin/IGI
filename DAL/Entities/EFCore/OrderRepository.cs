using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Entities.EFCore
{
    public class OrderRepository : Interfaces.EntityInterfaces.IOrderRepository
    {
        private bool disposedValue;

        public OrderRepository(Interfaces.EFCore.EFContextBasic context)
        {
            _context = context;
        }

        public string ConnectionString
        {
            get => _conStr;
            set => _conStr = $"Data Source={value};";
        }

        public bool Add(Order record)
        {
            try
            {
                this._context.Orders.Add(record);
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

        public IEnumerable<Order> GetAll()
        {
            try
            {
                return _context.Orders.AsEnumerable().ToList();
                //return _context.Orders.Select(e => e).AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception($"In {this.GetType().Name} repository exception: {ex.Message}", ex);
            }
        }

        public Order GetById(int Id)
        {
            try
            {
                return (Order)_context.Orders.Where(e => e.Id == Id);
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
                Order element = _context.Orders.Find(Id);
                _context.Orders.Remove(element);
                _context.SaveChanges();
                
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update(int Id, Order editedRecord)
        {
            bool flag = true;
            try
            {
                _context.Orders.Update(editedRecord);
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
