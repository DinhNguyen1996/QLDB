using BEQLDB.ServiceInterface.DAL.Interface;
using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.DAL.Repository
{
    public class ContactRepository1 : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository1(QLDBContext dbContext) : base(dbContext)
        {
        }

    }
}
