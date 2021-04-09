﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;

namespace DAL.Repository
{
    public class ADORepository<T> : IRepository<T>, IDisposable where T : DAL.Entities.BaseEntity, new()
    {
        public void Append(T entity)
        {
            object[] serialized = entity.Serialize();
            string values = String.Join(", ", serialized.Skip(1));
            using SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "BEGIN TRANSACTION;";
            command.ExecuteNonQuery();
            command.CommandText = $"INSERT INTO \"main\".\"{tableName}\" VALUES({"null," + values});";
            command.ExecuteNonQuery();
            command.CommandText = "COMMIT;";
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM \"main\".\"{tableName}\" WHERE Id={id} ";
            command.ExecuteNonQuery();
            command.CommandText = "COMMIT;";
            command.ExecuteNonQuery();
        }

        public T GetById(int id)
        {
            using SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM \"main\".\"{tableName}\" WHERE Id={id};";
            command.CommandType = System.Data.CommandType.Text;
            using SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                return default;
            }

            T result = new T();
            List<object> values = new List<object>();
            foreach (DbDataRecord rec in reader)
            {
                for (int i = 0; i < rec.FieldCount; i++)
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
                SQLiteCommand headerTest = new SQLiteCommand(connection);
                tableName = this.GetType().GetGenericArguments()[0].Name;
                headerTest.CommandText = $"SELECT tbl_name FROM \"main\".sqlite_master WHERE name=\"{tableName}\";";
                headerTest.CommandType = System.Data.CommandType.Text;
                using SQLiteDataReader reader = headerTest.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                if (!reader.HasRows)
                {
                    connection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            return flag;
        }

        public void Update(T entity)
        {
            IEnumerable<object> serialized = entity.Serialize().Skip(1);
            IEnumerable<System.Reflection.PropertyInfo> names = entity.GetType().GetProperties().Skip(1);
            List<string> namesAndValues = new List<string>();
            for (int i = 0; i < serialized.Count(); i++)
            {
                namesAndValues.Add($"\"{names.ElementAt(i).Name}\"={serialized.ElementAt(i)}");
            }
            using SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE \"main\".\"{tableName}\" SET {String.Join(", ", namesAndValues)} WHERE Id={entity.Id};";
            command.ExecuteNonQuery();
            command.CommandText = "COMMIT;";
            command.ExecuteNonQuery();
        }

        public List<T> Read()
        {
            using SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM \"main\".\"{tableName}\";";
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                return new List<T>();
            }

            List<T> result = new List<T>();
            foreach (DbDataRecord i in reader)
            {
                T record = new T();
                System.Collections.ArrayList fields = new(i.FieldCount);
                for (int j = 0; j < i.FieldCount; j++)
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
            GC.SuppressFinalize(this);
        }
    }
}
