using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;

namespace Estore.Ce.Contracts
{
    public interface IPreStockCountRepository : IBasePreTransactionRepository<PreStockCount>
    {
        PreStockCount GetPreStockCountByBarcode(string barcode);        
    }
}
