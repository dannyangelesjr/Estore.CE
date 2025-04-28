using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Estore.Ce.Models
{
    public class BaseTransactionEntity
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string DeviceId { get; set; }
        public int LineNumber { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime ScanDate { get; set; }
    }
}
