using BEQLDB.ServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal QLDBContext _dbContext;
        internal DbSet<T> _dbSet;
        public GenericRepository(QLDBContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Delete(object id)
        {
            T entityDelete = _dbSet.Find(id);
            Delete(entityDelete);
        }

        public void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Unchanged)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            Console.WriteLine("State : " + _dbContext.Entry(entity).State.ToString());
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }
    }
}
