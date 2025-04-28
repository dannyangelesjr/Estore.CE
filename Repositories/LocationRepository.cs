using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using Estore.Ce.Models;
using System.Windows.Forms;
using Estore.Ce.Repositories.Base;

namespace Estore.Ce.Repositories
{
    public interface ILocationRepository : IRepository<Location>, IBaseRepository<Location>
    {
        event Action<int, int> RecordUpdatedLocationRepository;
    }

    public class LocationRepository : ILocationRepository
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        // Get all entities from the table
        public IEnumerable<Location> GetAll()
        {
            List<Location> entities = new List<Location>();

            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Location";
                using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entities.Add(MapToEntity(reader));
                        }
                    }
                }
                connection.Close();
            }

            return entities;
        }

        // Add an entity to the database
        public void Insert(Location entity)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Location (LocationId, Name) VALUES (" + entity.LocationId + "," + entity.LocationName + ");";
                using (SqlCeCommand command = new SqlCeCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // Add an entity to the database
        public void InsertAll(IList<Location> entities)
        {
            using (SqlCeConnection connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();

                using (SqlCeTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int count = 0;
                        int recordCount = entities.Count;
                        foreach (var location in entities)
                        {
                            using (SqlCeCommand command = connection.CreateCommand())
                            {
                                command.Transaction = transaction;
                                command.CommandText = @"
                                INSERT INTO Location (LocationId, LocationName) 
                                VALUES (@LocationId,@LocationName)";

                                command.Parameters.AddWithValue("@LocationId", location.LocationId);
                                command.Parameters.AddWithValue("@LocationName", location.LocationName);

                                command.ExecuteNonQuery();

                                count++;
                                OnRecordUpdated(entities.Count, recordCount);
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Insert failed.", ex);
                    }
                }
            }
        }

        // Update an entity in the database
        public void Update(Location entity)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Location SET Name = " + entity.LocationName + " WHERE LocationId = " + entity.LocationId + ";";
                using (SqlCeCommand command = new SqlCeCommand(updateQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // Delete an entity from the database
        public void Delete(Location entity)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Location WHERE LocadtionId = " + entity.LocationId + ";";
                using (SqlCeCommand command = new SqlCeCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // Delete an entity from the database
        public void DeleteAll()
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Location";
                    using (SqlCeCommand command = new SqlCeCommand(deleteQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string queryResetIdentity = "ALTER TABLE Location ALTER COLUMN Id IDENTITY (1,1)";
                    using (SqlCeCommand command = new SqlCeCommand(queryResetIdentity, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlCeException ex)
            {
                // Log or inspect the exception to identify the problem
                MessageBox.Show("Error resetting identity: " + ex.Message);
            }
        }

        public Location MapToEntity(IDataRecord record)
        {
            var entity = new Location();

            foreach (var property in typeof(Location).GetProperties())
            {
                if (!record.IsDBNull(record.GetOrdinal(property.Name)))
                {
                    property.SetValue(entity, record[property.Name], null);
                }
            }

            return entity;
        }

        public event Action<int, int> RecordUpdatedLocationRepository;

        private void OnRecordUpdated(int recordsFound, int recordsUpdated)
        {
            if (RecordUpdatedLocationRepository != null)
            {
                RecordUpdatedLocationRepository(recordsFound, recordsUpdated);
                Application.DoEvents();
            }
        }
    }
}