using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.Common;
using System.Linq;
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
            DbCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM \"main\".\"{this.GetType().GetGenericArguments()[0].Name}\" WHERE Id={id} ";
            command.CommandType = System.Data.CommandType.Text;
            var reader = command.ExecuteReader();
            
            throw new NotImplementedException();
        }

        /// <summary>
        /// Открывает соединение с БД.
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД</param>
        /// <returns></returns>
        public bool Open(string connectionString)
        {
            bool flag = true;
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.ConnectionString = connectionString;
                connection.Open();
                var headerTest = new SQLiteCommand(connection);
                headerTest.CommandText = $"SELECT tbl_name FROM \"main\".sqlite_master WHERE name=\"{this.GetType().GetGenericArguments()[0].Name}\"";
                headerTest.CommandType = System.Data.CommandType.Text;
                SQLiteDataReader reader = headerTest.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                if (!reader.HasRows)
                {
                    connection.Close();
                    return false;
                }                
            }
            catch(Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> Read()
        {
            throw new NotImplementedException();
        }

        private SQLiteConnection connection = null;

        private string tableName = String.Empty;
    }
}
