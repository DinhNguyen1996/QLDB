using BEQLDB.ServiceInterface.DAL.Repository;
using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.DAL.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T>, IDisposable where T : class
    {
        private QLDBContext dbContext;
        public IGenericRepository<T> GenericRepository { get; set; }

        //public IGenericRepository<Network> NetworkRepository { get; set; }

        //public IGenericRepository<Contact> ContactRepository { get; set; } 

        public UnitOfWork(QLDBContext dbContext, IGenericRepository<T> repostory)
        {
            this.dbContext = dbContext;
            GenericRepository = repostory;
        }
        public virtual void Dispose()
        {
            dbContext.Dispose();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public async Task Save()
        {
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                //RollBack();
                throw;
            }
        }


    }
}
