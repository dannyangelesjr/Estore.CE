using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;
using System.Data.SqlServerCe;
using System.Data;

namespace Estore.Ce.Repositories.Base
{
    public interface IBasePreTransactionRepository<T> where T : BasePreTransactionEntity
    {    
    }

    public class BasePreTransactionRepository<T> : IBasePreTransactionRepository<T> where T:BasePreTransactionEntity
    {
    }
}