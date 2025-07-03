using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Estore.Ce.Models
{
    public class PreStockReplenishment : BasePreTransactionEntity
    {
        public int LocationFromId { get; set; }
        public int LocationToId { get; set; }
    }
}
