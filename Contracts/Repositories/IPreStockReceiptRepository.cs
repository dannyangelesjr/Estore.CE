using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Infrastructure.Repositories.Base;
using Estore.Ce.Models;

namespace Estore.Ce.Contracts
{
    public interface IPreStockReceiptRepository : IBasePreTransactionRepository<PreStockReceipt>
    {
        List<PreStockReceiptAggregate> GetPendingDeliveries();
        List<PreStockReceipt> GetBySupplierInvoiceNumber(string supplierInvoiceNumber);
    }
}
