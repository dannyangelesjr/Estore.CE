using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;
using System.Data;
using System.Data.SqlServerCe;

namespace Estore.Ce.Contracts
{
    public interface IBasePreTransactionRepository<T> where T : BasePreTransactionEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetByBarcode(string barcode);

        T InsertUpdate(T entity);
        bool InsertAll(IEnumerable<T> entities);
        
        bool DeleteById(int id);
        bool DeleteAll();        
    }
}
