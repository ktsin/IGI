using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using CsvHelper;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;

namespace DAL
{
    public class CSVRepository<T> : IRepository<T> where T : Entities.BaseEntity
    {
        public void Append(T entity) 
        {
            {
                var file = File.Open(filename, FileMode.Append);
                using var fileStream = new StreamWriter(file);
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false
                };
                using var csv = new CsvWriter(fileStream, csvConfig);
                fileStream.NewLine = "\n";
                //get last Id:
                int lastId = 0;
                if(data.Count > 0)
                    lastId = data.Max((e) => e.Id);
                entity.Id = lastId + 1;
                csv.WriteRecord(entity);
                csv.Flush();
                fileStream.WriteLine("");
            }
            Refresh();
            
        }
        public void Refresh()
        {
            using var file = new StreamReader(File.OpenRead(filename));
            using var csv = new CsvReader(file, CultureInfo.InvariantCulture);
            data = csv.GetRecords<T>().ToList();
            
        }

        public void Delete()
        {
            Refresh();
            //throw new NotImplementedException();
        }

        public bool Open(string connectionString)
        {
            string typeName = this.GetType().GetGenericArguments()[0].Name+".csv";
            //here connectionString is path to *.csv file
            if (fileFormatRegex.IsMatch(connectionString + $"{typeName}") && Directory.Exists(connectionString))
            {
                
                using var file = new StreamReader(File.OpenRead(connectionString + $"{typeName}"));
                var csv = new CsvReader(file, CultureInfo.InvariantCulture);
                filename = connectionString+typeName;
                data = csv.GetRecords<T>().ToList();
                
                return true;
            }
            else
                return false;
        }

        public List<T> Read()
        {
            return data;
        }

        public void Update(T entity)
        {
            var last = GetById(entity.Id);
            //copying fields from old to new
            data.RemoveAll(e => e.Id == entity.Id);
            data = data.Append(entity).ToList<T>();
            using var fileStrem = new StreamWriter(File.Open(filename, FileMode.Truncate));
            using var cswWriter = new CsvWriter(fileStrem, CultureInfo.InvariantCulture);
            cswWriter.WriteHeader<T>();
            cswWriter.WriteRecords(data);
            fileStrem.Flush();
            fileStrem.WriteLine("");
        }

        public T GetById(int id)
        {
            return data.FirstOrDefault<T>(e => e.Id == id);
        }

        private List<T> data = new();

        private string filename = "";

        private readonly Regex fileFormatRegex = new Regex(".{1,}\\.csv");
    }
}
