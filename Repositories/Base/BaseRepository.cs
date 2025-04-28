using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Estore.Ce.Models;
using System.Data.SqlServerCe;
using System.Data;

namespace Estore.Ce.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        void Insert(T entity);
        void InsertAll(IList<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteAll();

        T MapToEntity(System.Data.IDataRecord record);        
    }

    //public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity    
    //{                
    //}
}