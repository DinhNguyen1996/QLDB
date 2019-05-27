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
        Task<Network> GetById(int id);
        Task<bool> Create(Network network);
        Task<bool> Update(Network network);
        Task<bool> Delete(int id);
    }
}
