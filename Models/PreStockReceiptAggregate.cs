using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Estore.Ce.Models
{
    public class PreStockReceiptAggregate
    {
        public string SupplierInvoiceNumber { get; set; }
        public string SupplierName { get; set; }
        public int PurchaseOrderNumber { get; set; }
    }
}
