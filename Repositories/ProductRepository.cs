using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using Estore.Ce.Models;
using Estore.Ce.Repositories;
using System.Windows.Forms;
using Estore.Ce.Repositories.Base;

namespace Estore.Ce.Repositories
{
    public interface IProductRepository : IRepository<Product>, IBaseRepository<Product>
    {
        event Action<string> StatusUpdatedProductRepository;
        event Action<int, int> RecordUpdatedProductRepository;

        Product GetProductByBarcode(string barcode);
        Product GetProductByProductId(int productId);
    }

    public class ProductRepository : IProductRepository
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        public event Action<string> StatusUpdatedProductRepository;
        public event Action<int, int> RecordUpdatedProductRepository;

        // Get all entities from the table
        public IEnumerable<Product> GetAll()
        {
            var entities = new List<Product>();

            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Product";
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

        public Product GetProductByBarcode(string barcode)
        {
            Product entity = new Product();
            int sw = 0;
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Product WHERE Barcode = '" + barcode + "'";
                using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sw = 1;
                            entity = (MapToEntity(reader));
                        }
                    }
                }
                connection.Close();
            }

            return sw != 0 ? entity : null;
        }

        public Product GetProductByProductId(int productId)
        {
            Product entity = new Product();
            int sw = 0;
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Product WHERE ProductId = " + productId ;
                using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sw = 1;
                            entity = (MapToEntity(reader));
                        }
                    }
                }
                connection.Close();
            }

            return sw != 0 ? entity : null;
        }

        // Add an entity to the database
        public void Insert(Product entity)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Product (ProductId, Name) VALUES (" + entity.ProductId + "," + entity.ProductName + ");";
                using (SqlCeCommand command = new SqlCeCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // Add an entity to the database
        public void InsertAll(IList<Product> entities)
        {
            string barcode = "";
            using (SqlCeConnection connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();

                using (SqlCeTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int count = 0;
                        int recordCount = entities.Count;
                        foreach (var product in entities)
                        {
                            using (SqlCeCommand command = connection.CreateCommand())
                            {
                                barcode = product.Barcode;

                                command.Transaction = transaction;
                                command.CommandText = @"
                                INSERT INTO Product (Barcode,Brand,Category,PackingSize,PackingUnit,ProductId,ProductParentId,ProductName,SellingPrice) 
                                VALUES (@Barcode,@Brand,@Category,@PackingSize,@PackingUnit,@ProductId,@ProductParentId,@ProductName,@SellingPrice)";

                                command.Parameters.AddWithValue("@Barcode", product.Barcode);
                                command.Parameters.AddWithValue("@Brand", product.Brand);
                                command.Parameters.AddWithValue("@Category", product.Category);
                                command.Parameters.AddWithValue("@PackingSize", product.PackingSize);
                                command.Parameters.AddWithValue("@PackingUnit", product.PackingUnit);
                                command.Parameters.AddWithValue("@ProductId", product.ProductId);
                                command.Parameters.AddWithValue("@ProductParentId", product.ProductParentId ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                                command.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);

                                command.ExecuteNonQuery();

                                count++;
                                OnStatusUpdated("Saving products (" + count + "/" + recordCount + ")");
                                OnRecordUpdated(entities.Count, count);
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
        public void Update(Product entity)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Product SET Name = " + entity.ProductName + " WHERE ProductId = " + entity.ProductId + ";";
                using (SqlCeCommand command = new SqlCeCommand(updateQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // Delete an entity from the database
        public void Delete(Product entity)
        {
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Product WHERE ProductId = " + entity.ProductId + ";";
                using (SqlCeCommand command = new SqlCeCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        // Delete all from the database
        public void DeleteAll()
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Product";
                    using (SqlCeCommand command = new SqlCeCommand(deleteQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    string queryResetIdentity = "ALTER TABLE Product ALTER COLUMN Id IDENTITY (1,1)";
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

        private void OnStatusUpdated(string status)
        {
            if (StatusUpdatedProductRepository != null)
            {
                StatusUpdatedProductRepository(status);
                Application.DoEvents();
            }
        }

        private void OnRecordUpdated(int recordsFound, int recordsUpdated)
        {
            if (RecordUpdatedProductRepository != null)
            {
                RecordUpdatedProductRepository(recordsFound, recordsUpdated);
                Application.DoEvents();
            }
        }

        public Product MapToEntity(IDataRecord record)
        {
            var entity = new Product();

            foreach (var property in typeof(Product).GetProperties())
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