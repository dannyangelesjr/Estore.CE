using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using Estore.Ce.Contracts;
using Estore.Ce.Helpers;
using Estore.Ce.Infrastructure.Repositories.Base;
using Estore.Ce.Models;

namespace Estore.Ce.Infrastructure.Repositories
{
    public class PreStockReceiptRepository : BasePreTransactionRepository<PreStockReceipt>, IPreStockReceiptRepository
    {
        private string _connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

        protected override string TableName
        {
            get { return "PreStockReceipt"; }
        }

        public List<PreStockReceiptAggregate> GetPendingDeliveries()
        {
            PreStockReceiptAggregate entity = null;
            List<PreStockReceiptAggregate> list = new List<PreStockReceiptAggregate>();

            using (SqlCeConnection connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string commandText = "SELECT SupplierInvoiceNumber,SupplierName,PurchaseOrderNumber FROM PreStockReceipt GROUP BY SupplierInvoiceNumber,SupplierName,PurchaseOrderNumber ORDER BY SupplierName,SupplierInvoiceNumber,PurchaseOrderNumber";
                using (SqlCeCommand cmd = new SqlCeCommand(commandText, connection))
                {
                    using (SqlCeDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entity = new PreStockReceiptAggregate();
                            entity = ObjectMapper.MapReaderToEntity<PreStockReceiptAggregate>(reader);
                            list.Add(entity);
                        }
                    }
                }
            }
            return list;
        }

        public List<PreStockReceipt> GetBySupplierInvoiceNumber(string supplierInvoiceNumber)
        {
            PreStockReceipt entity = null;
            List<PreStockReceipt> entities = new List<PreStockReceipt>();
            using (SqlCeConnection connection = new SqlCeConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM PreStockReceipt WHERE SupplierInvoiceNumber='" + supplierInvoiceNumber + "' ORDER BY LineNumber";
                using (SqlCeCommand command = new SqlCeCommand(selectQuery, connection))
                {
                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entity = ObjectMapper.MapReaderToEntity<PreStockReceipt>(reader);
                            entities.Add(entity);
                        }
                    }
                }
                connection.Close();
            }

            return entities;
        }

        public override PreStockReceipt InsertUpdate(PreStockReceipt entity)
        {
            try
            {
                using (var connection = new SqlCeConnection(_connectionString))
                {
                    connection.Open();

                    string commandText;


                    if (entity.Id == 0)
                    {
                        commandText = "INSERT INTO PreStockReceipt " +
                                "(Id, Barcode, DeviceId, LineNumber, PackingUnit, ProductId, ProductName, PurchaseOrderNumber, Quantity, QuantityOnOrder, ScanDate, SupplierName, SupplierInvoiceNumber) " +
                                "VALUES (@Id, @Barcode, @DeviceId, @LineNumber, @PackingUnit, @ProductId, @ProductName, @PurchaseOrderNumber, @Quantity, @QuantityOnOrder, @ScanDate, @SupplierName, @SupplierInvoiceNumber)";
                    }
                    else
                    {
                        commandText = "UPDATE PreStockReceipt SET " +
                                "Barcode=@Barcode, " +
                                "DeviceId=@DeviceId, " +
                                "LineNumber=@LineNumber, " +
                                "ProductId=@ProductId, " +
                                "PackingUnit=@PackingUnit, " +
                                "ProductName=@ProductName, " +
                                "PurchaseOrderNumber=@PurchaseOrderNumber, " +
                                "Quantity=@Quantity, " +
                                "QuantityOnOrder=@QuantityOnOrder, " +
                                "ScanDate=@ScanDate, " +
                                "SupplierName=@SupplierName, " +
                                "SupplierInvoiceNumber=@SupplierInvoiceNumber " +
                                "WHERE Id=@Id";
                    }

                    using (SqlCeCommand command = new SqlCeCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@Id", entity.Id);
                        command.Parameters.AddWithValue("@Barcode", entity.Barcode ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DeviceId", entity.DeviceId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@LineNumber", entity.LineNumber);
                        command.Parameters.AddWithValue("@PackingUnit", entity.PackingUnit);
                        command.Parameters.AddWithValue("@ProductId", entity.ProductId);
                        command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                        command.Parameters.AddWithValue("@PurchaseOrderNumber", entity.PurchaseOrderNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", entity.Quantity);
                        command.Parameters.AddWithValue("@QuantityOnOrder", entity.QuantityOnOrder);
                        command.Parameters.AddWithValue("@ScanDate", entity.ScanDate??(object)DBNull.Value);
                        command.Parameters.AddWithValue("@SupplierName", entity.SupplierName);
                        command.Parameters.AddWithValue("@SupplierInvoiceNumber", entity.SupplierInvoiceNumber);

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
