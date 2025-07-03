using System;
using System.Collections.Generic;
using Estore.Ce.Infrastructure.Repositories.Base;
using Estore.Ce.Models;
using System.Data.SqlServerCe;
using Estore.Ce.Contracts;

namespace Estore.Ce.Infrastructure.Repositories
{
    public class PreStockReplenishmentRepository : BasePreTransactionRepository<PreStockReplenishment>, IPreStockReplenishmentRepository
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        protected override string TableName
        {
            get { return "PreStockReplenishment"; }
        }        

        public override PreStockReplenishment InsertUpdate(PreStockReplenishment entity)
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();

                    string commandText;

                    if (entity.Id == 0)
                    {
                        commandText = "INSERT INTO PreStockReplenishment " +
                                "(Barcode, DeviceId, LineNumber, LocationFromId, LocationToId, PackingUnit, ProductId, ProductName, Quantity, ScanDate) " +
                                "VALUES (@Barcode, @DeviceId, @LineNumber, @LocationFromId, @LocationToId, @PackingUnit, @ProductId, @ProductName, @Quantity, @ScanDate)";
                    }
                    else
                    {
                        commandText = "UPDATE PreStockReplenishment SET " +
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
                        command.Parameters.AddWithValue("@Barcode", entity.Barcode ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DeviceId", entity.DeviceId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LineNumber", entity.LineNumber);                        
                        command.Parameters.AddWithValue("@LocationFromId", entity.LocationFromId);
                        command.Parameters.AddWithValue("@LocationToId", entity.LocationToId);
                        command.Parameters.AddWithValue("@PackingUnit", entity.PackingUnit);
                        command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                        command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                        command.Parameters.AddWithValue("@Quantity", entity.Quantity);
                        command.Parameters.AddWithValue("@ScanDate", entity.ScanDate??(object)DBNull.Value);                        

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
