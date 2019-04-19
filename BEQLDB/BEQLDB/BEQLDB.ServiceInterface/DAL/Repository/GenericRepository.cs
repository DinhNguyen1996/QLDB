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

        public void Delete(T entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void Delete(object id)
        {
            T entityDelete = _dbSet.Find(id);
            Delete(entityDelete);
        }

        public void Edit(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        IQueryable<T> IGenericRepository<T>.List()
        {
            return _dbSet.AsQueryable();
        }

        IQueryable<T> IGenericRepository<T>.List(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
