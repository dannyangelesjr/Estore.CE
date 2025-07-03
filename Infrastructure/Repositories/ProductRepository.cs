using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Estore.Ce.Contracts;
using Estore.Ce.Helpers;
using Estore.Ce.Infrastructure.Repositories.Base;
using Estore.Ce.Models;

namespace Estore.Ce.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        protected override string TableName
        {
            get { return "Product"; }
        }

        public Product GetByBarcode(string barcode)
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
                            entity = ObjectMapper.MapReaderToEntity<Product>(reader);
                        }
                    }
                }
                connection.Close();
            }

            return sw != 0 ? entity : null;
        }

        public Product GetByProductId(int productId)
        {
            try
            {
                Product entity = new Product();
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM Product WHERE ProductId = " + productId;
                    using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                entity = ObjectMapper.MapReaderToEntity<Product>(reader);
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

        public override bool Insert(Product entity)
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();
                    string commandText;

                    commandText =
                        "INSERT INTO Product (Barcode, Brand, Category, PackingSize, PackingUnit, ProductId, ProductParentId, ProductName, SellingPrice) "
                        + "VALUES (@Barcode, @Brand, @Category, @PackingSize, @PackingUnit, @ProductId, @ProductParentId, @ProductName, @SellingPrice)";


                    using (SqlCeCommand command = new SqlCeCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@Barcode", entity.Barcode);
                        command.Parameters.AddWithValue("@Brand", entity.Brand);
                        command.Parameters.AddWithValue("@Category", entity.Category);
                        command.Parameters.AddWithValue("@PackingSize", entity.PackingSize);
                        command.Parameters.AddWithValue("@PackingUnit", entity.PackingUnit);
                        command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                        command.Parameters.AddWithValue("@ProductParentId", entity.ProductParentId == null ? (object)DBNull.Value : entity.ProductParentId);
                        command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                        command.Parameters.AddWithValue("@SellingPrice", entity.SellingPrice);

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

        public override bool InsertAll(IEnumerable<Product> entities)
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();

                    foreach (Product entity in entities)
                    {
                        string commandText = "INSERT INTO Product (Barcode, Brand, Category, PackingSize, PackingUnit, ProductId, ProductParentId, ProductName, SellingPrice) " +
                            "VALUES (@Barcode, @Brand, @Category, @PackingSize, @PackingUnit, @ProductId, @ProductParentId, @ProductName, @SellingPrice)";

                        using (SqlCeCommand command = new SqlCeCommand(commandText, connection))
                        {                                                                                   
                            command.Parameters.AddWithValue("@Barcode", entity.Barcode);
                            command.Parameters.AddWithValue("@Brand", entity.Brand);
                            command.Parameters.AddWithValue("@Category", entity.Category);
                            command.Parameters.AddWithValue("@PackingSize", entity.PackingSize);
                            command.Parameters.AddWithValue("@PackingUnit", entity.PackingUnit);
                            command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                            command.Parameters.AddWithValue("@ProductParentId", entity.ProductParentId == null ? (object)DBNull.Value : entity.ProductParentId);
                            command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                            command.Parameters.AddWithValue("@SellingPrice", entity.SellingPrice);

                            command.ExecuteNonQuery();
                        }                        
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