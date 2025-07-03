using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using Estore.Ce.Contracts;
using Estore.Ce.Helpers;
using Estore.Ce.Models;

namespace Estore.Ce.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        protected abstract string TableName { get; }

        public event Action<string> StatusUpdated;
        public event Action<int, int> RecordUpdated;

        #region Public Methods
        public IEnumerable<T> GetAll()
        {
            List<T> entities = new List<T>();
            T entity = new T();

            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM " + TableName + " ORDER BY Id";
                    using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                entity = ObjectMapper.MapReaderToEntity<T>(reader);
                                //entity = MapToEntity(reader, entity);
                                if (entity != null)
                                {
                                    entities.Add(entity);
                                }
                            }
                        }
                    }
                    connection.Close();
                }

                return entities;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetById(int id)
        {
            try
            {
                T entity = new T();
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM " + TableName + " WHERE Id = " + id;
                    using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {                                
                                entity = ObjectMapper.MapReaderToEntity<T>(reader);
                                //entity = MapToEntity(reader, entity);
                            }
                        }
                    }
                    connection.Close();
                }
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public abstract bool Insert(T entity);

        public abstract bool InsertAll(IEnumerable<T> entities);

        public bool Delete(T entity)
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM " + TableName + " WHERE Id = " + entity.Id;
                    using (SqlCeCommand command = new SqlCeCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAll()
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM " + TableName;
                    using (SqlCeCommand command = new SqlCeCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string queryResetIdentity = "ALTER TABLE " + TableName + " ALTER COLUMN Id IDENTITY (1,1)";
                    using (SqlCeCommand command = new SqlCeCommand(queryResetIdentity, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
                return true;
            }
            catch (SqlCeException)
            {
                throw;
            }
        }

        public void OnStatusUpdated(string status)
        {
            if (StatusUpdated != null)
            {
                StatusUpdated(status);
                Application.DoEvents();
            }
        }

        public void OnRecordUpdated(int recordsFound, int recordsUpdated)
        {
            if (RecordUpdated != null)
            {
                RecordUpdated(recordsFound, recordsUpdated);
                Application.DoEvents();
            }
        }
        #endregion

        //#region Private Methods
        //private T MapToEntity(SqlCeDataReader reader, T entity)
        //{
        //    foreach (var property in typeof(T).GetProperties())
        //    {
        //        if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
        //        {
        //            property.SetValue(entity, reader[property.Name], null);
        //        }
        //    }

        //    return entity;
        //}
        //#endregion
    }
}
