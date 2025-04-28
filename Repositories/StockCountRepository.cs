using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Repositories.Base;
using System.Data.SqlServerCe;
using Estore.Ce.Models;
using System.Data;
using System.Windows.Forms;

namespace Estore.Ce.Repositories
{
    public interface IStockCountRepository : IBasePreTransactionRepository<PreStockCount>
    {
        IEnumerable<PreStockCount> GetAll();
        PreStockCount GetStockCountByBarcode(string barcode);
        PreStockCount MapToEntity(System.Data.IDataRecord record);

        void Insert(PreStockCount entity);
        void Update(PreStockCount entity);
        void Delete(PreStockCount entity);
        void DeleteAll();
    }

    public class StockCountRepository : BasePreTransactionRepository<PreStockCount>, IStockCountRepository
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        public IEnumerable<PreStockCount> GetAll()
        {
            List<PreStockCount> entities = new List<PreStockCount>();
            PreStockCount entity = null;
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM StockCount  ORDER BY Id";
                using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entity = MapToEntity(reader);
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

        public PreStockCount GetStockCountByBarcode(string barcode)
        {
            PreStockCount entity = null;
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM StockCount WHERE Barcode='" + @barcode + "'";
                using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entity = MapToEntity(reader);
                        }
                    }
                }
                connection.Close();
            }

            return entity;
        }

        public void Insert(PreStockCount entity)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO StockCount (Barcode, DeviceId, LocationId, PackingUnit, ProductId, ProductName, Quantity, ScanDate) " +
                    "VALUES ('" + entity.Barcode + "','" + entity.DeviceId + "'," + entity.LocationId + ",'" + entity.PackingUnit + "'," + entity.ProductId + ",'" + entity.ProductName + "'," + entity.Quantity + ",'" + DateTime.Now + "');";
                using (SqlCeCommand command = new SqlCeCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Update(PreStockCount entity)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string insertQuery = "UPDATE StockCount SET " +
                    "Barcode='" + entity.Barcode + "'," +
                    "DeviceId='" + entity.DeviceId + "'," +
                    "LocationId=" + entity.LocationId + "," +
                    "ProductId=" + entity.ProductId + "," +
                    "Quantity=" + entity.Quantity + "," +
                    "ScanDate='" + DateTime.Now + "' " +
                    "WHERE ProductId = " + entity.ProductId;
                using (SqlCeCommand command = new SqlCeCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Delete(PreStockCount entity)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM StockCount WHERE ProductId = " + entity.ProductId;
                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DeleteAll()
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM StockCount";
                    using (SqlCeCommand command = new SqlCeCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string queryResetIdentity = "ALTER TABLE StockCount ALTER COLUMN Id IDENTITY (1,1)";
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

        public PreStockCount MapToEntity(IDataRecord record)
        {
            var entity = new PreStockCount();

            foreach (var property in typeof(PreStockCount).GetProperties())
            {
                if (!record.IsDBNull(record.GetOrdinal(property.Name)))
                {
                    property.SetValue(entity, record[property.Name], null);
                }
            }

            return entity;
        }
    }
}
