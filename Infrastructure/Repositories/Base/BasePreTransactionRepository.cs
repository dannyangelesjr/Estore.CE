using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Estore.Ce.Contracts;
using Estore.Ce.Helpers;
using Estore.Ce.Models;

namespace Estore.Ce.Infrastructure.Repositories.Base
{
    public abstract class BasePreTransactionRepository<T> : IBasePreTransactionRepository<T> where T:BasePreTransactionEntity,new()
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        protected abstract string TableName { get; }
        
        public IEnumerable<T> GetAll()
        {
            List<T> entities = new List<T>();

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
                                T entity = null;
                                entity = ObjectMapper.MapReaderToEntity<T>(reader);
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

        public T GetByBarcode(string barcode)
        {
            try
            {
                T entity = null;
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM " + TableName + " WHERE Barcode = '" + barcode + "'";
                    using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                entity = ObjectMapper.MapReaderToEntity<T>(reader);
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

        public T GetById(int id)
        {
            try
            {
                T entity = null;
                using(var connection = new SqlCeConnection(_connectionString))
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

        public bool InsertAll(IEnumerable<T> entities)
        {
            try
            {
                foreach (T entity in entities)
                {
                    InsertUpdate(entity);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public abstract T InsertUpdate(T entity);

        public bool DeleteById(int id)
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM " + TableName + " WHERE Id = " + id;
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
    }
}