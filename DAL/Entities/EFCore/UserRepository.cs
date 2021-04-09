using System;
using System.Collections.Generic;

namespace DAL.Entities.EFCore
{
    public class UserRepository : Interfaces.EntityInterfaces.IUserRepository
    {
        private bool disposedValue;
        public UserRepository(Interfaces.EFCore.EFContextBasic context)
        {
            _context = context;
        }
        public string ConnectionString
        {
            get => _conStr;
            set => _conStr = $"Data Source={value};";
        }

        public bool Add(User record)
        {
            if (this._context == null)
            {
                throw new NullReferenceException("Repository does not opened;");
            }

            try
            {
                this._context.Users.Add(record);
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

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Open()
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int Id, User editedRecord)
        {
            throw new NotImplementedException();
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
