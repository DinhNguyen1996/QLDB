using BEQLDB.ServiceInterface.DAL.Interface;
using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.DAL.Repository
{
    public class NetworkRepository : GenericRepository<Network>,INetworkRepository
    {
        public NetworkRepository(QLDBContext dbContext) : base(dbContext)
        {
        }
    }
}
