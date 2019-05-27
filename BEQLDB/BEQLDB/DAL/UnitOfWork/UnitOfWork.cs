using BEQLDB.ServiceInterface.DAL.Repository;
using BEQLDB.ServiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private QLDBContext dbContext;
       
        public UnitOfWork(QLDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual void Dispose()
        {
            dbContext.Dispose();
        }
        
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
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
                RollBack();
                throw;
            }
        }

        public void RollBack()
        {
            var changedEntries = dbContext.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

    }
}
