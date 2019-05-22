using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEQLDB.ServiceInterface.IServices
{
    public interface INetworkService 
    {
        List<Network> GetAll();
        Network GetById(int id);
        bool Create(Network network);
        bool Update(Network network);
        bool Delete(int id);
    }
}
