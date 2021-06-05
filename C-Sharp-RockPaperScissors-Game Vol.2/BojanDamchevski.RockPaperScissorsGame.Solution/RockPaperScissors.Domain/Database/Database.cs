using Newtonsoft.Json;
using RockPaperScissors.Domain.Interfaces;
using RockPaperScissors.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RockPaperScissors.Domain.Database
{
    public class Database<T> : IDatabase<T> where T : BaseEntity
    {
        private string _folderPath;
        private string _filePath;
        private int _id;
        public Database()
        {
            _id = 0;
            _folderPath = @"..\..\..\Db";
            _filePath = _folderPath + @$"\{typeof(T).Name}s.json";
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
                WriteData(new List<T>());
            }
        }
        public List<T> GetAll()
        {
            return GetData();
        }

        public T GetbyId(int id)
        {
            List<T> dbEntities = GetData();
            return dbEntities.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(T entity)
        {
            List<T> dbEntities = GetData();
            if (dbEntities == null)
            {
                dbEntities = new List<T>();
                _id = 1;
            }
            else
            {
                _id = dbEntities.Count + 1;
            }
            entity.Id = _id;
            dbEntities.Add(entity);
            WriteData(dbEntities);
            return entity.Id;
        }

        public void RemoveById(int id)
        {
            List<T> dbEntities = GetData();
            T entityDb = dbEntities.FirstOrDefault(x => x.Id == id);
            if (entityDb == null)
            {
                Console.WriteLine("User doesn't exist.");
            }
            dbEntities.Remove(entityDb);
            WriteData(dbEntities);
        }

        public void Update(T entity)
        {
            List<T> dbEntities = GetData();
            T entityDb = dbEntities.FirstOrDefault(x => x.Id == entity.Id);
            if (entityDb == null)
            {
                Console.WriteLine("User doesn't exist.");
            }
            dbEntities[dbEntities.IndexOf(entityDb)] = entity;
            WriteData(dbEntities);
        }

        private void WriteData(List<T> dbEntities)
        {
            using (StreamWriter streamWriter = new StreamWriter(_filePath))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(dbEntities));
            }
        }

        private List<T> GetData()
        {
            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                return JsonConvert.DeserializeObject<List<T>>(streamReader.ReadToEnd());
            }
        }
    }
}
