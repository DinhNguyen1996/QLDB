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
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        IQueryable<T> GetPage(int PageSize, int PageIndex);
        Task Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Delete(object id);
        Task<T> GetById(object id);
    }
}
