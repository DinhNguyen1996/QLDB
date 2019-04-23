using BEQLDB.ServiceInterface.DAL.Repository;
using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.DAL.UnitOfWork
{
    public interface IUnitOfWork<T> where T : class
    {
        //IGenericRepository<Network> NetworkRepository { get; }
        //IGenericRepository<Contact> ContactRepository { get; }
        IGenericRepository<T> GenericRepository { get; }

        Task Save();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        //void RejectChanges();
        void Dispose(bool disposing);
    }
}
