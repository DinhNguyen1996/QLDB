using BEQLDB.ServiceInterface.DAL.Interface;
using BEQLDB.ServiceInterface.DAL.Repository;
using BEQLDB.ServiceInterface.DAL.UnitOfWork;
using BEQLDB.ServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        //protected readonly IUnitOfWork<T> _unitOfWork;
        //protected readonly IGenericRepository<T> _genericRepo;

        //public BaseService(IUnitOfWork<T> unitOfWork, IGenericRepository<T> genericRepo)
        //{
        //    this._unitOfWork = unitOfWork;
        //    this._genericRepo = genericRepo;
        //}
        //public virtual async Task<T> Create(T entity)
        //{
        //    _genericRepo.Create(entity);
        //    await _unitOfWork.Save();
        //    return entity;
        //}
        //public virtual async Task<T> Delete(Expression<Func<T, bool>> keySelector)
        //{
        //    var entity = await _genericRepo.GetById(keySelector: keySelector);
        //    if (entity == null)
        //        throw new Exception("Cannot find");

        //    _genericRepo.Delete(entity);
        //    await _unitOfWork.Save();
        //    return entity;

        //}
        //public virtual async Task<T> Delete(T entity)
        //{
        //    _genericRepo.Delete(entity);
        //    await _unitOfWork.Save();
        //    return entity;
        //}

        //public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        //{
        //    var entities = await _genericRepo.GetAll(filter, orderBy, includeProperties).ToListAsync();
        //    return entities.AsEnumerable();
        //}

        //public virtual async Task<T> GetById(Expression<Func<T, bool>> keySelector, string includeProperties = "")
        //{
        //    var entity = await _genericRepo.GetById(keySelector, includeProperties);
        //    if (entity == null)
        //        throw new Exception("Cannot find");

        //    return entity;
        //}

        //public virtual async Task<IEnumerable<object>> GetModelsWithKeys(params string[] keys)
        //{
        //    foreach (string key in keys)
        //    {
        //        var propertyInfo = typeof(T).GetProperty(key);
        //        if (propertyInfo == null)
        //            throw new EntryPointNotFoundException();
        //    }

        //    var entities = await _genericRepo.GetAll().Select(
        //        x => new
        //        {
        //        }).ToListAsync();

        //    return entities;
        //}
        //public virtual async Task<T> Update(T entity)
        //{
        //    _genericRepo.Update(entity);
        //    await _unitOfWork.Save();
        //    return entity;
        //}

    }
}
