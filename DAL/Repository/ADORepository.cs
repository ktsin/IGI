using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class ADORepository<T> : IRepository<T>, IDisposable where T : DAL.Entities.BaseEntity, new()
    {
        public void Append(T entity)
        {
            var serialized = entity.Serialize();
            var values = String.Join(", ", serialized).Skip(1);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO \"main\".\"{tableName}\" VALUES({"null,"+values})";
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM \"main\".\"{tableName}\" WHERE Id={id} ";
            command.ExecuteNonQuery();
        }

        public T GetById(int id)
        {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM \"main\".\"{tableName}\" WHERE Id={id} ";
            command.CommandType = System.Data.CommandType.Text;
            var reader = command.ExecuteReader();
            if (!reader.HasRows)
                return default;
            var result = new T();
            var values = new List<object>();
            foreach(DbDataRecord rec in reader)
            {
                for(int i = 0; i < rec.FieldCount; i++)
                {
                    values.Add(rec[i]);
                }
            }
            result.Deserialize(values.ToArray());
            reader.Close();
            return result;
        }

        /// <summary>
        /// Открывает соединение с БД.
        /// </summary>
        /// <param name="connectionString">Путь к бд</param>
        /// <returns></returns>
        public bool Open(string connectionString)
        {
            bool flag = true;
            try
            {
                connection = new SQLiteConnection($"Data Source={connectionString};Cache=Shared");
                connection.Open();
                var headerTest = new SQLiteCommand(connection);
                tableName = this.GetType().GetGenericArguments()[0].Name;
                headerTest.CommandText = $"SELECT tbl_name FROM \"main\".sqlite_master WHERE name=\"{tableName}\"";
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
            var serialized = entity.Serialize().Skip(1);
            var values = String.Join(", ", serialized);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE \"main\".\"{tableName}\" VALUES({"null,"+values}) WHERE Id={entity.Id};";
            command.ExecuteNonQuery();
        }

        public List<T> Read()
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM \"main\".\"{tableName}\";";
            var reader = command.ExecuteReader();
            if (!reader.HasRows)
                return new List<T>();
            var result = new List<T>();
            foreach(DbDataRecord i in reader)
            {
                var record = new T();
                System.Collections.ArrayList fields = new(i.FieldCount);
                for(int j = 0; j < i.FieldCount; j++)
                {
                    fields.Add(i[j]);
                }
                record.Deserialize(fields.ToArray());
                result.Add(record);
            }
            return result;
        }

        private SQLiteConnection connection = null;

        private string tableName = String.Empty;

        public void Dispose()
        {
            connection.Close();
        }
    }
}
