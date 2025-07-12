using System;
using System.Data.SqlServerCe;
using Estore.Ce.Contracts;
using Estore.Ce.Helpers;
using Estore.Ce.Infrastructure.Repositories.Base;
using Estore.Ce.Models;

namespace Estore.Ce.Infrastructure.Repositories
{
    public class PreStockCountRepository : BasePreTransactionRepository<PreStockCount>, IPreStockCountRepository
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        protected override string TableName
        {
            get { return "PreStockCount"; }
        }

        public PreStockCount GetPreStockCountByBarcode(string barcode)
        {
            PreStockCount entity = null;
            using (var connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM PreStockCount WHERE Barcode='" + @barcode + "'";
                using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entity = ObjectMapper.MapReaderToEntity<PreStockCount>(reader);
                        }
                    }
                }
                connection.Close();
            }

            return entity;
        }

        public override PreStockCount InsertUpdate(PreStockCount entity)
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();

                    string commandText;

                    if (entity.Id == 0)
                    {
                        commandText = "INSERT INTO PreStockCount " +
                                "(Barcode, DeviceId, LineNumber, LocationId, PackingUnit, ProductId, ProductName, Quantity, ScanDate) " +
                                "VALUES (@Barcode, @DeviceId, @LineNumber, @LocationId, @PackingUnit, @ProductId, @ProductName, @Quantity, @ScanDate)";
                    }
                    else
                    {
                        commandText = "UPDATE PreStockCount SET " +
                                "Barcode=@Barcode, " +
                                "DeviceId=@DeviceId, " +
                                "ProductId=@ProductId, " +
                                "PackingUnit=@PackingUnit, " +
                                "ProductName=@ProductName, " +
                                "Quantity=@Quantity, " +
                                "ScanDate=@ScanDate " +
                                "WHERE Id=@Id";
                    }

                    using (SqlCeCommand command = new SqlCeCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@Id", entity.Id);
                        command.Parameters.AddWithValue("@Barcode", entity.Barcode);
                        command.Parameters.AddWithValue("@DeviceId", entity.DeviceId);
                        command.Parameters.AddWithValue("@LineNumber", entity.LineNumber);
                        command.Parameters.AddWithValue("@LocationId", entity.LocationId);
                        command.Parameters.AddWithValue("@PackingUnit", entity.PackingUnit);
                        command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                        command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                        command.Parameters.AddWithValue("@Quantity", entity.Quantity);
                        command.Parameters.AddWithValue("@ScanDate", DateTime.Now);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                    return GetByBarcode(entity.Barcode);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}
