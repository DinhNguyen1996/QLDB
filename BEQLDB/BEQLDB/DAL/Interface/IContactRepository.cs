using BEQLDB.ServiceInterface.DAL.Repository;
using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.DAL.Interface
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
    }
}
