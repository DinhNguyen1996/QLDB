using BEQLDB.ServiceInterface;
using BEQLDB.ServiceInterface.DAL.Repository;
using BEQLDB.ServiceInterface.DAL.UnitOfWork;
using BEQLDB.ServiceInterface.IServices;
using BEQLDB.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Imp
{
    public class NetworkService : INetworkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Network> _networkRepo;

        public NetworkService(IUnitOfWork unitOfWork, IGenericRepository<Network> networkRepo)
        {
            _unitOfWork = unitOfWork;
            _networkRepo = networkRepo;
        }

        public bool Create(Network network)
        {
            _networkRepo.Create(network);
            _unitOfWork.Save();
            return true;
        }

        public bool Delete(int id)
        {
            _networkRepo.Delete(id);
            _unitOfWork.Save();
            return true;
        }

        public List<Network> GetAll()
        {
            var listNetwork = _networkRepo.GetAll();
            return listNetwork?.ToList();
        }

        public Network GetById(int id)
        {
            var network = _networkRepo.GetById(id);
            return network;
        }


        public bool Update(Network network)
        {
            var networkUpdate = _networkRepo.GetById(network.id);
            if (networkUpdate != null)
            {
                networkUpdate.nameNetwork = network.nameNetwork;

                _networkRepo.Update(networkUpdate);
                _unitOfWork.Save();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
