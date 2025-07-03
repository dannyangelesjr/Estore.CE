using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;

namespace Estore.Ce.Contracts
{
    public interface IPreStockDamageRepository : IBasePreTransactionRepository<PreStockDamage>
    {
        PreStockDamage GetPreStockDamageByBarcode(string barcode);        
    }
}
