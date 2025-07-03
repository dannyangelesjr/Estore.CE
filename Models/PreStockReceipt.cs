using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Estore.Ce.Models
{
    public class PreStockReceipt : BasePreTransactionEntity
    {
        public int? PurchaseOrderNumber { get; set; }
        public int QuantityOnOrder { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public string SupplierName { get; set; }        
    }
}
