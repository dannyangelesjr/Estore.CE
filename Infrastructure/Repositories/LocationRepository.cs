using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Estore.Ce.Contracts;
using Estore.Ce.Helpers;
using Estore.Ce.Infrastructure.Repositories.Base;
using Estore.Ce.Models;

namespace Estore.Ce.Infrastructure.Repositories
{
    public enum LocationType
    {
        BadOrder,
        SellingArea,
        Warehouse
    }

    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        protected override string TableName
        {
            get { return "Location"; }
        }

        public Location GetByLocationType(LocationType locationType)
        {
            try
            {
                Location entity = null;
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();

                    string selectQuery;
                    switch (locationType)
                    {
                        case LocationType.BadOrder:
                            selectQuery = "SELECT * FROM Location WHERE IsBadOrder = 1";
                            break;
                        case LocationType.SellingArea:
                            selectQuery = "SELECT * FROM Location WHERE IsSellingArea = 1";
                            break;
                        default:
                            selectQuery = "SELECT * FROM Location WHERE IsWarehouse = 1";
                            break;
                    }


                    using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                entity = ObjectMapper.MapReaderToEntity<Location>(reader);
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

        // Add an entity to the database
        public override bool Insert(Location entity)
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();

                    string commandText;
                    commandText = "INSERT INTO Location (LocationId, LocationName, IsBadOrder, IsSellingArea, IsWarehouse) VALUES (" + entity.LocationId + ",'" + entity.LocationName + "'," + Convert.ToInt32(entity.IsBadOrder) + "," + Convert.ToInt32(entity.IsSellingArea) + "," + Convert.ToInt32(entity.IsWarehouse) + ");";

                    using (SqlCeCommand command = new SqlCeCommand(commandText, connection))
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

        public override bool InsertAll(IEnumerable<Location> entities)
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();

                    foreach (Location entity in entities)
                    {
                        Insert(entity);
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
    }
}