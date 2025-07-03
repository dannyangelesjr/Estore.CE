using System;
using Estore.Ce.Models;

namespace Estore.Ce.Contracts
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        event Action<string> StatusUpdated;
        event Action<int, int> RecordUpdated;

        Product GetByBarcode(string barcode);
        Product GetByProductId(int productId);
    }
}
