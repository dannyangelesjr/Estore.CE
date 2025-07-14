using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;
using System.Data.SqlServerCe;
using System.Data;

namespace Estore.Ce.Contracts
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetByProductId(int productId);

        bool Insert(T entity);
        bool InsertAll(IEnumerable<T> entities);
        
        bool Delete(T entity);
        bool DeleteAll();        
    }    
}