using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;
using System.Data.SqlServerCe;
using System.Data;

namespace Estore.Ce.Repositories.Base
{
    public interface IBaseTransactionRepository<T> where T : BaseTransactionEntity
    {    
    }

    public class BaseTransactionRepository<T> : IBaseTransactionRepository<T> where T:BaseTransactionEntity
    {
    }
}