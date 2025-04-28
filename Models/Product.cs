using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;

namespace Estore.Ce.Models
{
    public class Product:BaseEntity
    {
        public string Barcode { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int PackingSize { get; set; }
        public string PackingUnit { get; set; }
        public int ProductId { get; set; }
        public int? ProductParentId { get; set; }
        public string ProductName { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
