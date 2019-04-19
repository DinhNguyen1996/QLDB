using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(object id);
        IQueryable<T> List();
        IQueryable<T> List(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Delete(object id);
    }
}
